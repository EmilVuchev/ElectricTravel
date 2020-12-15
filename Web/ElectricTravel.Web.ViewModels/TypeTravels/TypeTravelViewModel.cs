namespace ElectricTravel.Web.ViewModels.TypeTravels
{
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Mapping;

    public class TypeTravelViewModel : IMapFrom<TypeTravel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
