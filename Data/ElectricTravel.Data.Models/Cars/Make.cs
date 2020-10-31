namespace ElectricTravel.Data.Models.Cars
{
    using System;
    using System.Collections.Generic;

    public class Make
    {
        public Make()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Models = new HashSet<Model>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
