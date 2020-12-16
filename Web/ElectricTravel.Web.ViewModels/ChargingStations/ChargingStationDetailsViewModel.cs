namespace ElectricTravel.Web.ViewModels.ChargingStations
{
    using System.ComponentModel.DataAnnotations;

    public class ChargingStationDetailsViewModel : ChargingStationDeleteDetailsViewModel
    {
        [Display(Name = "City")]
        public string CityName { get; set; }

        public string Address { get; set; }
    }
}
