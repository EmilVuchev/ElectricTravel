// ReSharper disable VirtualMemberCallInConstructor
namespace ElectricTravel.Data.Models.Location
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;

    public class Address : BaseModel<int>
    {
        public string Street { get; set; }

        [Required]
        [MaxLength(30)]
        public string District { get; set; }

        [Required]
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
