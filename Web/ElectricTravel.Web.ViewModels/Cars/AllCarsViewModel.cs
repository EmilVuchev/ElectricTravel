namespace ElectricTravel.Web.ViewModels.Cars
{
    using System.Linq;

    using AutoMapper;
    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.ViewModels.Images;

    public class AllCarsViewModel : IMapFrom<ElectricCar>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Battery { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string ElectricityConsumption { get; set; }

        public string Description { get; set; }

        public ImageViewModel Image { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
           configuration.CreateMap<ElectricCar, AllCarsViewModel>()
                .ForMember(
                m => m.Image,
                opt => opt.MapFrom(x => x.Images.FirstOrDefault()));
        }
    }
}
