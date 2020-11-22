namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Mapping;

    public class SharedTravelsViewModel : IMapFrom<SharedTravelAdvert>
    {
        public string Id { get; set; }

        public DateTime StartDateAndTime { get; set; }

        public string Date => this.StartDateAndTime.ToString("dd-MM-yyyy");

        public string Hour => this.StartDateAndTime.ToString("HH:mm");

        public DayOfWeek Day => this.StartDateAndTime.DayOfWeek;

        public int Seats { get; set; }

        public bool SmokeRestriction { get; set; }

        [Display(Name = "Smoke restriction")]
        public string SmokeRestrictionAsString => this.SmokeRestriction == false ? "Yes" : "No";

        public bool PlaceForLuggage { get; set; }

        [Display(Name = "Luggage")]
        public string PlaceForLuggageAsString => this.PlaceForLuggage == false ? "Yes" : "No";

        public bool WithReturnTrip { get; set; }

        [Display(Name = "Return trip")]
        public string WithReturnTripAsString => this.WithReturnTrip == false ? "Yes" : "No";

        public string TypeOfTravelName { get; set; }

        public string StartDestinationName { get; set; }

        public string EndDestinationName { get; set; }

        public SharedTravelStatus Status { get; set; }

        public string CreatedByUserName { get; set; }
    }
}
