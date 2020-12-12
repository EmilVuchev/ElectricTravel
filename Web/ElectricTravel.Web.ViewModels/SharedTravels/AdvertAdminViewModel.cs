namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Mapping;

    public class AdvertAdminViewModel : IMapFrom<SharedTravelAdvert>
    {
        public string Id { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartDateAndTime { get; set; }

        public int Seats { get; set; }

        [Display(Name = "Type of Travel")]
        public string TypeOfTravelName { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByUserName { get; set; }

        [Display(Name = "From")]
        public string StartDestinationName { get; set; }

        [Display(Name = "To")]
        public string EndDestinationName { get; set; }

        public string StatusName { get; set; }
    }
}
