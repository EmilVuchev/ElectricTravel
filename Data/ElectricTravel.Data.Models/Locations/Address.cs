// ReSharper disable VirtualMemberCallInConstructor
namespace ElectricTravel.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Street { get; set; }

        [Required]
        [MaxLength(30)]
        public string District { get; set; }

        [Required]
        [ForeignKey(nameof(City))]
        public string CityId { get; set; }

        public virtual City City { get; set; }
    }
}
