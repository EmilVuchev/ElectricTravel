namespace ElectricTravel.Data.Models.Cars
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Model
    {
        public Model()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        [ForeignKey(nameof(Make))]
        public string MakeId { get; set; }

        public virtual Make Make { get; set; }
    }
}
