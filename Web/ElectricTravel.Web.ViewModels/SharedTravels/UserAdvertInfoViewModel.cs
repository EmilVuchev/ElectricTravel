namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Mapping;

    public class UserAdvertInfoViewModel : IMapFrom<ElectricTravelUser>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
