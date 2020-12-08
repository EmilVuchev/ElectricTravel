namespace ElectricTravel.Web.ViewModels.Cars
{
    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Services.Mapping;

    public class VehicleModelViewModel : IMapFrom<Model>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int VehicleMakeId { get; set; }
    }
}
