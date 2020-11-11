namespace ElectricTravel.Data.Models.Multimedia
{
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public class ImageType : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
