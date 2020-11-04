namespace ElectricTravel.Data.Models.Charging
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;

    public class StationPayment : IDeletableEntity
    {
        [ForeignKey(nameof(ChargingStation))]
        public int ChargingStationId { get; set; }

        public virtual ChargingStation ChargingStation { get; set; }

        [ForeignKey(nameof(Payment))]
        public int PaymentId { get; set; }

        public virtual PaymentMethod Payment { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
