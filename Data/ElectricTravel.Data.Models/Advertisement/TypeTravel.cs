namespace ElectricTravel.Data.Models.Advertisement
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public class TypeTravel : BaseDeletableModel<int>
    {
        public TypeTravel()
        {
            this.SharedTravelAdvert = new HashSet<SharedTravelAdvert>();
        }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<SharedTravelAdvert> SharedTravelAdvert { get; set; }
    }
}
