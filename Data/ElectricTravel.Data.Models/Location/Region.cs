// ReSharper disable VirtualMemberCallInConstructor
namespace ElectricTravel.Data.Models.Location
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public class Region : BaseDeletableModel<int>
    {
        public Region()
        {
            this.Cities = new HashSet<City>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
