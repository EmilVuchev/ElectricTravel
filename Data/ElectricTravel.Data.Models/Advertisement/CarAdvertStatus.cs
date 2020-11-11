namespace ElectricTravel.Data.Models.Advertisement
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public class CarAdvertStatus : BaseDeletableModel<int>
    {
        public CarAdvertStatus()
        {
            this.CarAdverts = new HashSet<CarAdvert>();
        }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public virtual ICollection<CarAdvert> CarAdverts { get; set; }
    }
}
