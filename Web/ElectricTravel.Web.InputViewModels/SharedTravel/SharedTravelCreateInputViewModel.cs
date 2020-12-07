namespace ElectricTravel.Web.InputViewModels.SharedTravel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Common;
    using ElectricTravel.Web.InputViewModels.Common;

    public class SharedTravelCreateInputViewModel 
    {
        [Display(Name = InputViewModelsConstants.StartTripDateAndTime)]
        public DateTime StartDateAndTime { get; set; }

        [Range(InputViewModelsConstants.SeatsRangeMinValue, InputViewModelsConstants.SeatsRangeMaxValue)]
        public int Seats { get; set; }

        [Required]
        [Display(Name = GlobalConstants.Smoking)]
        public string SmokeRestriction { get; set; }

        [Required]
        [Display(Name = GlobalConstants.PlaceForLuggage)]
        public string PlaceForLuggage { get; set; }

        [Required]
        [Display(Name = GlobalConstants.ReturnTrip)]
        public string WithReturnTrip { get; set; }

        [Range(InputViewModelsConstants.TravelTypeAsNumMinRange, InputViewModelsConstants.TravelTypeAsNumMaxRange)]
        [Display(Name = GlobalConstants.TravelType)]
        public int TypeOfTravelId { get; set; }

        [Display(Name = GlobalConstants.StartDestinationTitle)]
        public int StartDestinationId { get; set; }

        [Display(Name = GlobalConstants.EndDestinationTitle)]
        public int EndDestinationId { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TypesOfTravel { get; set; }
    }
}
