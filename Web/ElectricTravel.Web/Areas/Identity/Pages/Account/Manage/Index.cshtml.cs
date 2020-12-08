namespace ElectricTravel.Web.Areas.Identity.Pages.Account.Manage
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using ElectricTravel.Common;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.Images;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ElectricTravelUser> userManager;
        private readonly SignInManager<ElectricTravelUser> signInManager;
        private readonly IUsersService usersService;
        private readonly IImagesService imagesService;
        private readonly IWebHostEnvironment environment;

        public IndexModel(
            UserManager<ElectricTravelUser> userManager,
            SignInManager<ElectricTravelUser> signInManager,
            IUsersService usersService,
            IImagesService imagesService,
            IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.usersService = usersService;
            this.imagesService = imagesService;
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

            [Required]
            [Display(Name = "You are a")]
            public string Role { get; set; }

            public IEnumerable<string> Roles { get; set; }
        }

        private async Task LoadAsync(ElectricTravelUser user)
        {
            var userName = await this.userManager.GetUserNameAsync(user);
            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            this.Username = userName;
            var userRoles = await this.userManager.GetRolesAsync(user);

            var roles = new List<string>();

            if (userRoles[0] == GlobalConstants.DriverRoleName)
            {
                roles.Add(userRoles[0]);
                roles.Add(GlobalConstants.PassengerRoleName);
            }
            else
            {
                roles.Add(userRoles[0]);
                roles.Add(GlobalConstants.DriverRoleName);
            }

            this.Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = phoneNumber,
                Roles = roles,
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

            if (this.Input.Role == GlobalConstants.DriverRoleName)
            {
                await this.userManager.RemoveFromRoleAsync(user, GlobalConstants.PassengerRoleName);
                await this.userManager.AddToRoleAsync(user, GlobalConstants.DriverRoleName);
            }
            else
            {
                await this.userManager.RemoveFromRoleAsync(user, GlobalConstants.DriverRoleName);
                await this.userManager.AddToRoleAsync(user, GlobalConstants.PassengerRoleName);
            }

            if (this.Input.Images != null)
            {
                var imageUploadModel = new ImageUploadViewModel();
                imageUploadModel.CarId = null;
                imageUploadModel.UserId = user.Id;
                imageUploadModel.Images = this.Input.Images;
                imageUploadModel.Path = $"{this.environment.WebRootPath}/img";
                imageUploadModel.ImageTypeName = GlobalConstants.UserImageType;

                await this.imagesService.UploadImages(imageUploadModel);
            }

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";
            return this.RedirectToPage();
        }
    }
}
