namespace ElectricTravel.Data.Models
{
    using System;

    public class CarType
    {
        public CarType()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
