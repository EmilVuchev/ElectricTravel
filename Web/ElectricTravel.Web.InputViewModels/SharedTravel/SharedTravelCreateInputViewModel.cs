namespace ElectricTravel.Web.InputViewModels.SharedTravel
{
    using System;

    using ElectricTravel.Data.Models.Advertisement.Enumerations;

    public class SharedTravelCreateInputViewModel
    {
        public DateTime StartDateAndTime { get; set; }

        public int Seats { get; set; }

        public bool SmokeRestriction { get; set; }

        public bool PlaceForLuggage { get; set; }

        public bool WithReturnTrip { get; set; }

        public TypeTravel TypeOfTravel { get; set; }

        public string StartDestinationName { get; set; }

        public SharedTravelStatus Status { get; set; }

        public int StartDestinationId { get; set; }

        public int EndDestinationId { get; set; }

        public string CreatedById { get; set; }
    }
}
