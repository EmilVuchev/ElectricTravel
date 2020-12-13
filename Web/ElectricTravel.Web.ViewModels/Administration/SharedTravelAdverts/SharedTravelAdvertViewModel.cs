namespace ElectricTravel.Web.ViewModels.Administration.SharedTravelAdverts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Common;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Mapping;

    public class SharedTravelAdvertViewModel : IMapFrom<SharedTravelAdvert>
    {
        public string Id { get; set; }

        [Display(Name = "Date and Time")]
        public DateTime StartDateAndTime { get; set; }

        [Display(Name = "From")]
        public string StartDestinationName { get; set; }

        [Display(Name = "To")]
        public string EndDestinationName { get; set; }

        public int Seats { get; set; }

        [Display(Name = "Is Approved")]
        public bool IsApproved { get; set; }

        [Display(Name = "Is Approved")]
        public string IsApprovedAsText => this.IsApproved == true ? GlobalConstants.TrueState : GlobalConstants.FalseState;

        [Display(Name = "Type of Travel")]
        public string TypeOfTravelName { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByUserName { get; set; }

        public bool SmokeRestriction { get; set; }

        [Display(Name = "Smoke Restriction")]
        public string SmokeRestrictionAsText => this.SmokeRestriction == true ? GlobalConstants.TrueState : GlobalConstants.FalseState;

        public bool PlaceForLuggage { get; set; }

        [Display(Name = "Place for Luggage")]
        public string PlaceForLuggageAsText => this.PlaceForLuggage == true ? GlobalConstants.TrueState : GlobalConstants.FalseState;

        public bool WithReturnTrip { get; set; }

        [Display(Name = "Return Trip")]
        public string ReturnTripAsText => this.WithReturnTrip == true ? GlobalConstants.TrueState : GlobalConstants.FalseState;

        public string Description { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
    }
}
