namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System;

    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Models.Advertisement.Enumerations;
    using ElectricTravel.Services.Mapping;

    public class SharedTravelsViewModel : IMapFrom<SharedTravelAdvert>
    {
        public int Id { get; set; }

        public DateTime StartDateAndTime { get; set; }

        public string Date => this.StartDateAndTime.ToString("dd-MM-yyyy");

        public string Hour => this.StartDateAndTime.ToString("HH:mm");

        public DayOfWeek Day => this.StartDateAndTime.DayOfWeek;

        public int Seats { get; set; }

        public bool SmokeRestriction { get; set; }

        public bool PlaceForLuggage { get; set; }

        public bool WithReturnTrip { get; set; }

        public TypeTravel TypeOfTravel { get; set; }

        // public virtual City StartDestination { get; set; }
        public string StartDestinationName { get; set; }

        // public virtual City EndDestination { get; set; }
        public string EndDestinationName { get; set; }

        public CarAdvertStatus Status { get; set; }

        // public virtual ElectricTravelUser CreatedBy { get; set; }
        public string CreatedByUserName { get; set; }
    }
}
