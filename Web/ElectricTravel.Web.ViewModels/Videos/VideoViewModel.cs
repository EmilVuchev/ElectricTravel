namespace ElectricTravel.Web.ViewModels.Videos
{
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Services.Mapping;

    public class VideoViewModel : IMapFrom<Video>
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }

        public string Description { get; set; }
    }
}
