namespace ElectricTravel.Web.ViewModels.ChargingStations
{
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Models.Charging;
    using ElectricTravel.Services.Mapping;

    public class ChargingStationViewModel : IMapFrom<ChargingStation>
    {
        public int Id { get; set; }

        [Display(Name = "Charging Station")]
        public string Name { get; set; }

        [Display(Name = "Work Time")]
        public string WorkTime { get; set; }

        [Display(Name = "Is Free Of Charge")]
        public bool IsFreeOfCharge { get; set; }

        public string Address { get; set; }
    }
}
