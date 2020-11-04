namespace ElectricTravel.Data.Models.Charging
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Charging.Enums;
    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Data.Models.Multimedia;

    public class ChargingStation : BaseModel<int>
    {
        public ChargingStation()
        {
            this.Sockets = new HashSet<Socket>();
            this.StationPayments = new HashSet<StationPayment>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string WorkTime { get; set; }

        public StationCategory Category { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public bool IsFreeOfCharge { get; set; }

        [ForeignKey(nameof(Address))]
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }

        [ForeignKey(nameof(Image))]
        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<StationPayment> StationPayments { get; set; }

        public virtual ICollection<Socket> Sockets { get; set; }
    }
}
