// ReSharper disable VirtualMemberCallInConstructor
namespace ElectricTravel.Data.Models.Location
{
    using System.Collections.Generic;

    using ElectricTravel.Data.Common.Models;

    public class Region : BaseDeletableModel<int>
    {
        public Region()
        {
            this.Cities = new HashSet<City>();
        }

        public virtual ICollection<City> Cities { get; set; }
    }
}
