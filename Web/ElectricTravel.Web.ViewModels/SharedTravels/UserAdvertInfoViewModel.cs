namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System.Linq;

    using AutoMapper;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Mapping;

    public class UserAdvertInfoViewModel : IMapFrom<ElectricTravelUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string ImagePath { get; set; }

        public string CarMake { get; set; }

        public string CarModel { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ElectricTravelUser, UserAdvertInfoViewModel>()
                .ForMember(x => x.Rating, opt =>
                opt.MapFrom(x => x.UserRatings.Count == 0 ? 0 : x.UserRatings.Average(r => r.Value)));
        }
    }
}
