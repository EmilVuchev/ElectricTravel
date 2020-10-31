namespace ElectricTravel.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Area
    {
        public Area()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
