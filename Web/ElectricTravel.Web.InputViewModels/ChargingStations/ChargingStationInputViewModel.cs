namespace ElectricTravel.Web.InputViewModels.ChargingStations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Web.InputViewModels.Addresses;

    public class ChargingStationInputViewModel
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Station")]
        public string Name { get; set; }

        [MaxLength(10)]
        [Display(Name = "Working Time")]
        public string WorkTime { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Display(Name = "Is Free Of Charge")]
        public bool IsFreeOfCharge { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }
    }
}
