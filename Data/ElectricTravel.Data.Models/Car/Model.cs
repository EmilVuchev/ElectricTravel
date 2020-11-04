namespace ElectricTravel.Data.Models.Car
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;

    public class Model : BaseModel<int>
    {
        public string Name { get; set; }

        public int Year { get; set; }

        [Required]
        [ForeignKey(nameof(Make))]
        public int MakeId { get; set; }

        public virtual Make Make { get; set; }
    }
}
