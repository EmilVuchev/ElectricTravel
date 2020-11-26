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

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ElectricTravelUser> _userManager;
        private readonly SignInManager<ElectricTravelUser> _signInManager;
        private readonly IUsersService usersService;
        private readonly IWebHostEnvironment environment;

        public IndexModel(
            UserManager<ElectricTravelUser> userManager,
            SignInManager<ElectricTravelUser> signInManager,
            IUsersService usersService,
            IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        }

        private async Task LoadAsync(ElectricTravelUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await this._userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this._userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            var phoneNumber = await this._userManager.GetPhoneNumberAsync(user);

            if (this.Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await this._userManager.SetPhoneNumberAsync(user, this.Input.PhoneNumber);
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
                await this.usersService.UploadImages(user, this.Input.Images, $"{this.environment.WebRootPath}/images");
            }

            await this._signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";
            return this.RedirectToPage();
        }
    }
}
