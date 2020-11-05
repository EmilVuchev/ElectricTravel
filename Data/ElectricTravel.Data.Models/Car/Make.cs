namespace ElectricTravel.Data.Models.Car
{
    using System.Collections.Generic;

    using ElectricTravel.Data.Common.Models;

    public class Make : BaseModel<int>
    {
        public Make()
        {
            this.Models = new HashSet<Model>();
            this.CarTypes = new HashSet<CarTypeMake>();
        }

        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        public virtual ICollection<CarTypeMake> CarTypes { get; set; }
    }
}
