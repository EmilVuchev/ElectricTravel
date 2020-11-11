namespace ElectricTravel.Data.Models.Advertisement
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public class SharedTravelStatus : BaseDeletableModel<int>
    {
        public SharedTravelStatus()
        {
            this.SharedTravelAdverts = new HashSet<SharedTravelAdvert>();
        }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public virtual ICollection<SharedTravelAdvert> SharedTravelAdverts { get; set; }
    }
}
