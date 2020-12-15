namespace ElectricTravel.Web.ViewModels.Regions
{
    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Services.Mapping;

    public class RegionViewModel : IMapFrom<Region>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
