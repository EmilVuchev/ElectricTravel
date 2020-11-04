namespace ElectricTravel.Data.Models.Multimedia
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Multimedia.Enumerations;

    public class Image : BaseModel<int>
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Path { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ImageType Type { get; set; }
    }
}
