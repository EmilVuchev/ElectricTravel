namespace ElectricTravel.Web.ViewModels.ChargingStations
{
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Models.Charging;
    using ElectricTravel.Services.Mapping;

    public class ChargingStationDeleteDetailsViewModel : IMapFrom<ChargingStation>
    {
        public int Id { get; set; }

        [Display(Name = "Station")]
        public string Name { get; set; }

        [Display(Name = "Working Time")]
        public string WorkTime { get; set; }

        public string Description { get; set; }
    }
}
