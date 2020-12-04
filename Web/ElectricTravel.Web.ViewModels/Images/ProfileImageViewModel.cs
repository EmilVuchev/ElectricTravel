namespace ElectricTravel.Web.ViewModels.Images
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class ProfileImageViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        [Display(Name = "Input images")]
        public IEnumerable<IFormFile> Files { get; set; }
    }
}
