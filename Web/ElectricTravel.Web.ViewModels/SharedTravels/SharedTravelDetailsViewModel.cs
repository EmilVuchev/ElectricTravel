namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System;

    using AutoMapper;
    using ElectricTravel.Common;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Mapping;

    public class SharedTravelDetailsViewModel : IMapFrom<SharedTravelAdvert>, IHaveCustomMappings
    {
        public DateTime StartDateAndTime { get; set; }

        public int Seats { get; set; }

        public string SmokeRestriction { get; set; }

        public string PlaceForLuggage { get; set; }

        public string WithReturnTrip { get; set; }

        public string TypeOfTravelName { get; set; }

        public string StartDestinationName { get; set; }

        public string EndDestinationName { get; set; }

        public string StatusName { get; set; }

        public string CreatedById { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<SharedTravelAdvert, SharedTravelDetailsViewModel>()
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
