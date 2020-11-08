namespace ElectricTravel.Data.Models.Charging
{
    using ElectricTravel.Data.Common.Models;

    public class SocketPower : BaseDeletableModel<int>
    {
        public int KilowattHour { get; set; }
    }
}
