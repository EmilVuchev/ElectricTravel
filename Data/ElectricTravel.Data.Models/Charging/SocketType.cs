namespace ElectricTravel.Data.Models.Charging
{
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public class SocketType : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
