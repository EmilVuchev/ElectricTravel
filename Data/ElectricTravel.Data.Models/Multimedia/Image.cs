namespace ElectricTravel.Data.Models.Multimedia
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Extension { get; set; }

        [Required]
        public string Path { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        public virtual ImageType Type { get; set; }
    }
}
