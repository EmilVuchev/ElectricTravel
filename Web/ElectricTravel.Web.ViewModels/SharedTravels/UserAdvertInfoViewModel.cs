namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Mapping;

    public class UserAdvertInfoViewModel : IMapFrom<ElectricTravelUser>
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string ImagePath { get; set; }

        public string CarMake { get; set; }

        public string CarModel { get; set; }
    }
}
