namespace ElectricTravel.Web.ViewModels.Images
{
    using System.ComponentModel.DataAnnotations;

    public class ImageViewModel
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }
    }
}
