namespace ElectricTravel.Web.InputViewModels.Images
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;

    public class ImageUploadViewModel
    {
        public string UserId { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public string Path { get; set; }

        public string ImageTypeName { get; set; }

        public int? CarId { get; set; }
    }
}
