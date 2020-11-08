namespace ElectricTravel.Data.Models.Charging
{
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;

    public class Socket : BaseDeletableModel<int>
    {
        [ForeignKey(nameof(Power))]
        public int PowerId { get; set; }

        public virtual SocketPower Power { get; set; }

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        public SocketType Type { get; set; }
    }
}
