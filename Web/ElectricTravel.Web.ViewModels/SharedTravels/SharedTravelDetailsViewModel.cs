namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System;

    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Mapping;

    public class SharedTravelDetailsViewModel : IMapFrom<SharedTravelAdvert>
    {
        public DateTime StartDateAndTime { get; set; }

        public int Seats { get; set; }

        public bool SmokeRestriction { get; set; }

        public bool PlaceForLuggage { get; set; }

        public bool WithReturnTrip { get; set; }

        public TypeTravel TypeOfTravel { get; set; }

        public City StartDestination { get; set; }

        public City EndDestination { get; set; }

        public SharedTravelStatus Status { get; set; }

        public virtual ElectricTravelUser CreatedBy { get; set; }
    }
}
