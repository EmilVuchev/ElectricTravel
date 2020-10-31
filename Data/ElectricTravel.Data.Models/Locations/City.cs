// ReSharper disable VirtualMemberCallInConstructor
namespace ElectricTravel.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City : Area
    {
        public City()
        {
            this.Addresses = new HashSet<Address>();
        }

        [ForeignKey(nameof(Region))]
        public string RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
