namespace ElectricTravel.Web.ViewModels.Cars
{
    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Services.Mapping;

    public class DriverCarViewModel : IMapFrom<ElectricCar>
    {
        public string MakeName { get; set; }

        public string ModelName { get; set; }
    }
}
