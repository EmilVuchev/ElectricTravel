namespace ElectricTravel.Web.ViewModels.Images
{
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Services.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }
    }
}
