namespace ElectricTravel.Data.Models.Charging
{
    using ElectricTravel.Data.Common.Models;

    public class SocketPower : BaseModel<int>
    {
        public int KilowattHour { get; set; }
    }
}
