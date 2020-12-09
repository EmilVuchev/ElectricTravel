namespace ElectricTravel.Web.ViewModels.Cars
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.ViewModels.Images;

    public class CarViewModel : IMapFrom<ElectricCar>
    {
        public int Id { get; set; }

        [Display(Name ="Make: ")]
        public string MakeName { get; set; }

        public int MakeId { get; set; }

        [Display(Name = "Model: ")]
        public string ModelName { get; set; }

        public int ModelId { get; set; }

        [Display(Name = "Range: ")]
        public double Range { get; set; }

        [Display(Name = "Kilometres: ")]
        public int Kilometres { get; set; }

        [Display(Name = "Acceleration: ")]
        public string Acceleration { get; set; }

        [Display(Name = "Top Speed: ")]
        public double TopSpeed { get; set; }

        [Display(Name = "Battery: ")]
        public string Battery { get; set; }

        [Display(Name = "Consumption: ")]
        public string ElectricityConsumption { get; set; }

        [Display(Name = "Drive: ")]
        public string Drive { get; set; }

        [Display(Name = "Year: ")]
        public int Year { get; set; }

        [Display(Name = "Horse Power: ")]
        public int HorsePower { get; set; }

        [Display(Name = "Seats: ")]
        public int Seats { get; set; }

        [Display(Name = "Doors: ")]
        public int Doors { get; set; }

        [Display(Name = "Description: ")]
        public string Description { get; set; }

        [Display(Name = "Color: ")]
        public string Color { get; set; }

        [Display(Name = "Luggage Capacity: ")]
        public int? LuggageCapacity { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }
    }
}
