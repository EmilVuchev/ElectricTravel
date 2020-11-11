namespace ElectricTravel.Web.InputViewModels.SharedTravel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SharedTravelCreateInputViewModel
    {
        [Display(Name = "Start trip date")]
        public DateTime StartDateAndTime => DateTime.UtcNow;

        [Range(1, 7)]
        public int Seats { get; set; }

        [Display(Name = "Smoking restriction")]
        public bool SmokeRestriction { get; set; }

        [Display(Name = "Place for luggage")]
        public bool PlaceForLuggage { get; set; }

        [Display(Name = "With return trip")]
        public bool WithReturnTrip { get; set; }

        [Display(Name = "Trip starts from")]
        public int StartDestinationId { get; set; }

        [Display(Name = "Trip ends at")]
        public int EndDestinationId { get; set; }

        public string CreatedById { get; set; }

        [Display(Name = "Advert Status")]
        public int StatusId { get; set; }

        [Display(Name = "Travel type")]
        public int TypeOfTravelId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TypesOfTravel { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Status { get; set; }
    }
}
