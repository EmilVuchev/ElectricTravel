namespace ElectricTravel.Web.ViewModels.Cars
{
    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Services.Mapping;

    public class VehicleMakeViewModel : IMapFrom<Make>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
