namespace ElectricTravel.Data.Models.Location
{
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public abstract class Area : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
