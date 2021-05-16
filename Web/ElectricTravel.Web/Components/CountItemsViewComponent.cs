namespace ElectricTravel.Web.Components
{
    using System.Threading.Tasks;

    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.ViewModels.ViewComponents;
    using Microsoft.AspNetCore.Mvc;

    public class CountItemsViewComponent : ViewComponent
    {
        private readonly IArticlesService articlesService;
        private readonly ISharedTravelsService sharedTravelsService;

        public CountItemsViewComponent(IArticlesService articlesService, ISharedTravelsService sharedTravelsService)
        {
            this.articlesService = articlesService;
            this.sharedTravelsService = sharedTravelsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articlesCount = await this.articlesService.GetArticlesCount();
            var sharedTravelAdvertsCount = await this.sharedTravelsService.GetAllApprovedAdvertsCount();

            var model = new CountArticlesAndAdvertsViewModel
            {
                AdvertsCount = sharedTravelAdvertsCount,
                NewsCount = articlesCount,
            };

            return this.View(model);
        }
    }
}
