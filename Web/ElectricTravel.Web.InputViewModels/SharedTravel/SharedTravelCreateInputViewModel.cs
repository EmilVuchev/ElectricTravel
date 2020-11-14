namespace ElectricTravel.Web.InputViewModels.SharedTravel
{
    using ElectricTravel.Data.Models.User;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SharedTravelCreateInputViewModel
    {
        [Display(Name = "Start trip date")]
        public DateTime StartDateAndTime { get; set; }

        [Range(1, 7)]
        public int Seats { get; set; }

        [Display(Name = "Smoking restriction")]
        public string SmokeRestriction { get; set; }

        [Display(Name = "Place for luggage")]
        public string PlaceForLuggage { get; set; }

        [Display(Name = "With return trip")]
        public string WithReturnTrip { get; set; }

        [Range(1, 3)]
        [Display(Name = "Travel type")]
        public int TypeOfTravelId { get; set; }

        [Display(Name = "Trip starts from")]
        public int StartDestinationId { get; set; }

        [Display(Name = "Trip ends at")]
        public int EndDestinationId { get; set; }

        public string CreatedById { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TypesOfTravel { get; set; }
    }
}
