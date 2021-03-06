﻿namespace ElectricTravel.Data.Models.Car
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public class CarType : BaseDeletableModel<int>
    {
        public CarType()
        {
            this.Cars = new HashSet<ElectricCar>();
            this.Makes = new HashSet<CarTypeMake>();
        }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<ElectricCar> Cars { get; set; }

        public virtual ICollection<CarTypeMake> Makes { get; set; }
    }
}
