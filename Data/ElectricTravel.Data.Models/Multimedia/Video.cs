namespace ElectricTravel.Data.Models.Multimedia
{
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public class Video : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Path { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
