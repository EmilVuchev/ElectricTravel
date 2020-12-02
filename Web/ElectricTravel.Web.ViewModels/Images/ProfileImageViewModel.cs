namespace ElectricTravel.Web.ViewModels.Images
{
    using AutoMapper.Configuration.Annotations;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Services.Mapping;

    public class ProfileImageViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string Path { get; set; }

        [Ignore]
        public bool IsForDeletion { get; set; }
    }
}
