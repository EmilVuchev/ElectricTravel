namespace ElectricTravel.Data.Models.Car
{
    using ElectricTravel.Data.Common.Models;

    public class CarType : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
