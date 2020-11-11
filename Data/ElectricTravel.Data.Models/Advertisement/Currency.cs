namespace ElectricTravel.Data.Models.Advertisement
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public class Currency : BaseDeletableModel<int>
    {
        public Currency()
        {
            this.CarAdverts = new HashSet<CarAdvert>();
        }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public virtual ICollection<CarAdvert> CarAdverts { get; set; }
    }
}
