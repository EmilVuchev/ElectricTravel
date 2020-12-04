using Microsoft.AspNetCore.Http;
using MyFirstAspNetCoreApplication.ValidationAttributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectricTravel.Web.InputViewModels.ElectricCars
{
    public class ElectricCarInputViewModel
    {
        [Range(50.0, 2000.0)]
        public double Range { get; set; }

        [Display(Name = "Kilometrage")]
        [Range(0, 2000000)]
        public int Kilometres { get; set; }

        [MaxLength(10)]
        public string Acceleration { get; set; }

        [Display(Name = "Top speed")]
        [Range(100.0, 700.0)]
        public double TopSpeed { get; set; }

        [Required]
        [MaxLength(10)]
        public string Battery { get; set; }

        [Display(Name = "Consumtion")]
        [MaxLength(10)]
        public string ElectricityConsumption { get; set; }

        [MaxLength(10)]
        public string Drive { get; set; }

        [CurrentYearMaxValue(1900)]
        public int Year { get; set; }

        [Display(Name = "Horse power")]
        [Range(50, 2000)]
        public int HorsePower { get; set; }

        [Range(3, 20)]
        public int Seats { get; set; }

        [Range(3, 5)]
        public int Doors { get; set; }

        [MaxLength(20)]
        public string Color { get; set; }

        [Display(Name = "Luggage capacity")]
        [Range(50, 5000)]
        public int? LuggageCapacity { get; set; }

        [Display(Name = "Car type")]
        public int CarTypeId { get; set; }

        [Display(Name = "Car make")]
        public int CarMakeId { get; set; }

        [Display(Name = "Car model")]
        public int CarModelId { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CarTypes { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CarMakes { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CarModels { get; set; }
    }
}
