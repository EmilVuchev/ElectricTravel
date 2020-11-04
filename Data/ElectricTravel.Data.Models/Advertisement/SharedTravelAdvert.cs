﻿namespace ElectricTravel.Data.Models.Advertisement
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Advertisement.Enumerations;
    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Data.Models.User;

    public class SharedTravelAdvert : BaseModel<int>
    {
        public DateTime StartDateAndTime { get; set; }

        public DateTime Date => this.StartDateAndTime.Date;

        public int Hour => this.StartDateAndTime.Hour;

        public DayOfWeek Day => this.StartDateAndTime.DayOfWeek;

        public int Seats { get; set; }

        public bool SmokeRestriction { get; set; }

        public bool PlaceForLuggage { get; set; }

        public bool WithReturnTrip { get; set; }

        public TypeTravel TypeOfTravel { get; set; }

        [ForeignKey(nameof(StartDestination))]
        public int StartDestinationId { get; set; }

        public virtual City StartDestination { get; set; }

        [ForeignKey(nameof(EndDestination))]
        public int EndDestinationId { get; set; }

        public virtual City EndDestination { get; set; }

        public AdvertStatus Status { get; set; }

        [Required]
        [ForeignKey(nameof(CreatedBy))]
        public string CreatedById { get; set; }

        public virtual ElectricTravelUser CreatedBy { get; set; }
    }
}