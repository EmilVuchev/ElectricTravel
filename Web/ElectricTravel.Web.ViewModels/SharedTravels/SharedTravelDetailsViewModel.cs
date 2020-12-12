namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;
    using ElectricTravel.Common;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Mapping;

    public class SharedTravelDetailsViewModel : IMapFrom<SharedTravelAdvert>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Display(Name = "Departure time:")]
        public DateTime StartDateAndTime { get; set; }

        [Display(Name = "Available seats: ")]
        public int Seats { get; set; }

        [Display(Name = "Smoke restriction: ")]
        public string SmokeRestriction { get; set; }

        [Display(Name = "Place for luggage: ")]
        public string PlaceForLuggage { get; set; }

        [Display(Name = "With return trip: ")]
        public string WithReturnTrip { get; set; }

        [Display(Name = "Travel type: ")]
        public string TypeOfTravelName { get; set; }

        [Display(Name = "From: ")]
        public string StartDestinationName { get; set; }

        [Display(Name = "To: ")]
        public string EndDestinationName { get; set; }

        public string CreatedById { get; set; }

        [Display(Name = "Driver: ")]
        public string CreatedByUserName { get; set; }

        [Display(Name = "Driver Rating: ")]
        public double Rating { get; set; }

        [Display(Name = "Description: ")]
        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<SharedTravelAdvert, SharedTravelDetailsViewModel>()
                .ForMember(x => x.Rating, opt =>
                    opt.MapFrom(x => x.CreatedBy.UserRatings.Count() == 0 ? 0 : x.CreatedBy.UserRatings.Average(v => v.Value)))
                .ForMember(
               m => m.SmokeRestriction,
               opt => opt.MapFrom(x => x.SmokeRestriction == true ? GlobalConstants.TrueState : GlobalConstants.FalseState))
                .ForMember(
                m => m.PlaceForLuggage,
                opt => opt.MapFrom(x => x.PlaceForLuggage == true ? GlobalConstants.TrueState : GlobalConstants.FalseState))
                .ForMember(
                m => m.WithReturnTrip,
                opt => opt.MapFrom(x => x.WithReturnTrip == true ? GlobalConstants.TrueState : GlobalConstants.FalseState));
        }
    }
}
