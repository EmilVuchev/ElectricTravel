namespace ElectricTravel.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.ViewModels.Images;
    using ElectricTravel.Web.ViewModels.Videos;

    public class CarViewModel : IMapFrom<ElectricCar>
    {
        public string CarMakeName { get; set; }

        public int CarMakeId { get; set; }

        public string CarModelName { get; set; }

        public int CarModelId { get; set; }

        public double Range { get; set; }

        public int Kilometres { get; set; }

        public string Acceleration { get; set; }

        public double TopSpeed { get; set; }

        public string Battery { get; set; }

        public string ElectricityConsumption { get; set; }

        public string Drive { get; set; }

        public int Year { get; set; }

        public int HorsePower { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public string Color { get; set; }

        public int? LuggageCapacity { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }

        public ICollection<VideoViewModel> Videos { get; set; }
    }
}
