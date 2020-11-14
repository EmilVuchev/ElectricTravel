namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Mapping;

    public class SharedTravelDetailsViewModel : IMapFrom<SharedTravelAdvert>
    {
        public string Id { get; set; }

        public DateTime StartDateAndTime { get; set; }

        public int Seats { get; set; }

        public bool SmokeRestriction { get; set; }

        public bool PlaceForLuggage { get; set; }

        public bool WithReturnTrip { get; set; }

        public string TypeOfTravel { get; set; }

        public string StartDestinationName { get; set; }

        public string EndDestinationName { get; set; }

        public string StatusName { get; set; }

        public UserAdvertInfoViewModel CreatedBy { get; set; }
    }
}
