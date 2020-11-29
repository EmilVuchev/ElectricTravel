namespace ElectricTravel.Web.InputViewModels.ElectricCars
{
    public class ElectricCarsInputViewModel
    {
        public int CarMakeId { get; set; }

        public int CarModelId { get; set; }

        public int CarTypeId { get; set; }

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

        //public ICollection<ImageViewModel> Images { get; set; }

        //public ICollection<VideoViewModel> Videos { get; set; }
    }
}
