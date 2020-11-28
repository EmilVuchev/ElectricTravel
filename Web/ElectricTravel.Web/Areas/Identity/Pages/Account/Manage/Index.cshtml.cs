namespace ElectricTravel.Web.Areas.Identity.Pages.Account.Manage
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ElectricTravelUser> userManager;
        private readonly SignInManager<ElectricTravelUser> signInManager;
        private readonly IUsersService usersService;
        private readonly IWebHostEnvironment environment;

        public IndexModel(
            UserManager<ElectricTravelUser> userManager,
            SignInManager<ElectricTravelUser> signInManager,
            IUsersService usersService,
            IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.usersService = usersService;
            this.environment = environment;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [MaxLength(20)]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [MaxLength(20)]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [EmailAddress]
            public string Email { get; set; }

            public IEnumerable<IFormFile> Images { get; set; }

            public IEnumerable<string> ImagesPaths { get; set; }
        }

        private async Task LoadAsync(ElectricTravelUser user)
        {
            var userName = await this.userManager.GetUserNameAsync(user);
            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            this.Username = userName;

            var userWithImages = await this.userManager.Users.Include(x => x.Images).SingleAsync();
            var imagesPaths = new List<string>();

            foreach (var image in userWithImages.Images)
            {
                imagesPaths.Add(image.Path);
            }

            this.Input = new InputModel
            {
                FirstName = userWithImages.FirstName,
                LastName = userWithImages.LastName,
                PhoneNumber = phoneNumber,
                ImagesPaths = imagesPaths,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            await this.LoadAsync(user);
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            if (this.Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await this.userManager.SetPhoneNumberAsync(user, this.Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    this.StatusMessage = "Unexpected error when trying to set phone number.";
                    return this.RedirectToPage();
                }
            }

            if (this.Input.FirstName != user.FirstName || this.Input.LastName != user.LastName)
            {
                try
                {
                    user.FirstName = this.Input.FirstName;
                    user.LastName = this.Input.LastName;

                    await this.usersService.UpdateUser(user);
                }
                catch (System.Exception)
                {
                    this.StatusMessage = "Unexpected error when trying to update user info.";
                    return this.RedirectToPage();
                }
            }

            if (this.Input.Images != null)
            {
                await this.usersService.UploadImages(user.Id, this.Input.Images, $"{this.environment.WebRootPath}/img");
            }

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";
            return this.RedirectToPage();
        }
    }
}
