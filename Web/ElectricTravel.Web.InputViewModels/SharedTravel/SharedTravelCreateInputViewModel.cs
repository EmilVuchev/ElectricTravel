namespace ElectricTravel.Web.InputViewModels.SharedTravel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ElectricTravel.Common;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Mapping;

    public class SharedTravelCreateInputViewModel : IMapTo<SharedTravelAdvert>, IHaveCustomMappings
    {
        [Display(Name = "Start trip date")]
        public DateTime StartDateAndTime { get; set; }

        [Range(1, 7)]
        public int Seats { get; set; }

        [Required]
        [Display(Name = "Smoking restriction")]
        public string SmokeRestriction { get; set; }

        [Required]
        [Display(Name = "Place for luggage")]
        public string PlaceForLuggage { get; set; }

        [Required]
        [Display(Name = "Return trip")]
        public string WithReturnTrip { get; set; }

        [Range(GlobalConstants.TravelTypeAsNumMinRange, GlobalConstants.TravelTypeAsNumMaxRange)]
        [Display(Name = "Travel type")]
        public int TypeOfTravelId { get; set; }

        [Display(Name = "Trip starts from")]
        public int StartDestinationId { get; set; }

        [Display(Name = "Trip ends at")]
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
