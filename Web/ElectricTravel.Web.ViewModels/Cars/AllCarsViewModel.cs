namespace ElectricTravel.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.ViewModels.Images;

    public class AllCarsViewModel : IMapFrom<ElectricCar>
    {
        public int Id { get; set; }

        public string Battery { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string ElectricityConsumption { get; set; }

        public string Description { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }
    }
}
