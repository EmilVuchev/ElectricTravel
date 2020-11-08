namespace ElectricTravel.Data.Models.News
{
    using ElectricTravel.Data.Common.Models;

    public class Source : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
