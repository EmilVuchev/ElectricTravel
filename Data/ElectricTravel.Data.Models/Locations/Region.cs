// ReSharper disable VirtualMemberCallInConstructor
namespace ElectricTravel.Data.Models
{
    using System.Collections.Generic;

    public class Region : Area
    {
        public Region()
        {
            this.Cities = new HashSet<City>();
        }

        public virtual ICollection<City> Cities { get; set; }
    }
}
