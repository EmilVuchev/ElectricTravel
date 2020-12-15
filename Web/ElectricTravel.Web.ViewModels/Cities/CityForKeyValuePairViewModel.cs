namespace ElectricTravel.Web.ViewModels.Cities
{
    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Services.Mapping;

    public class CityForKeyValuePairViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
