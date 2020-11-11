// ReSharper disable VirtualMemberCallInConstructor
namespace ElectricTravel.Data.Models.Location
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Advertisement;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Addresses = new HashSet<Address>();
            this.CarAdverts = new HashSet<CarAdvert>();
            this.StartPointAdvert = new HashSet<SharedTravelAdvert>();
            this.EndPointAdvert = new HashSet<SharedTravelAdvert>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<CarAdvert> CarAdverts { get; set; }

        [InverseProperty("StartDestination")]
        public virtual ICollection<SharedTravelAdvert> StartPointAdvert { get; set; }

        [InverseProperty("EndDestination")]
        public virtual ICollection<SharedTravelAdvert> EndPointAdvert { get; set; }
    }
}
