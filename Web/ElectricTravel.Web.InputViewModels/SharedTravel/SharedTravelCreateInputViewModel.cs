namespace ElectricTravel.Web.InputViewModels.SharedTravel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ElectricTravel.Common;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.Common;

    public class SharedTravelCreateInputViewModel : IMapTo<SharedTravelAdvert>, IHaveCustomMappings
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

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TypesOfTravel { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<SharedTravelCreateInputViewModel, SharedTravelAdvert>().ForMember(
                m => m.PlaceForLuggage,
                opt => opt.MapFrom(x => x.PlaceForLuggage == GlobalConstants.TrueState))
                .ForMember(
                m => m.SmokeRestriction,
                opt => opt.MapFrom(x => x.SmokeRestriction == GlobalConstants.TrueState))
                .ForMember(
                m => m.WithReturnTrip,
                opt => opt.MapFrom(x => x.WithReturnTrip == GlobalConstants.TrueState));
        }
    }
}
