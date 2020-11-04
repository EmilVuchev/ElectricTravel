namespace ElectricTravel.Data.Models.News
{
    using ElectricTravel.Data.Common.Models;

    public class Source : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
