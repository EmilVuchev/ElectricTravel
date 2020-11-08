namespace ElectricTravel.Data.Models.Charging
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;

    public class PaymentMethod : BaseDeletableModel<int>
    {
        public PaymentMethod()
        {
            this.StationsPayment = new HashSet<StationPayment>();
        }

        public string Name { get; set; }

        public virtual ICollection<StationPayment> StationsPayment { get; set; }
    }
}
