namespace ElectricTravel.Web.ViewModels.ChargingStations
{
    using System.ComponentModel.DataAnnotations;

    public class StationPaymentViewModel
    {
        [Display(Name = "Payment Method")]
        public string Name { get; set; }
    }
}
