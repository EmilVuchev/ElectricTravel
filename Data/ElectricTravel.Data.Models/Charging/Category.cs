namespace ElectricTravel.Data.Models.Charging
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Stations = new HashSet<StationCategory>();
        }

        [Required]
        [MaxLength(2)]
        public string Name { get; set; }

        public virtual ICollection<StationCategory> Stations { get; set; }
    }
}
