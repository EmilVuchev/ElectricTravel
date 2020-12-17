namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.Configuration.Annotations;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Mapping;

    public class DriverInfoViewModel : IMapFrom<ElectricTravelUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Display(Name = "Username: ")]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Name: ")]
        public string Name => this.FirstName + " " + this.LastName;

        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Display(Name = "Phone number: ")]
        public string PhoneNumber { get; set; }

        [Ignore]
        public string ImagePath { get; set; }

        [Display(Name = "Rating: ")]
        public double Rating { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ElectricTravelUser, DriverInfoViewModel>()
                .ForMember(x => x.Rating, opt =>
                opt.MapFrom(x => x.UserRatings.Count == 0 ? 0 : x.UserRatings.Average(r => r.Value)));
        }
    }
}
