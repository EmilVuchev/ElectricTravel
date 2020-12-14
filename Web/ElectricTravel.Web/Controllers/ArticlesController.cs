namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.News;
    using ElectricTravel.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly IArticlesService articlesService;
        private readonly UserManager<ElectricTravelUser> userManager;

        public ArticlesController(
            IArticlesService articlesService,
            UserManager<ElectricTravelUser> userManager)
        {
            this.articlesService = articlesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await this.articlesService.GetAllArticles<ArticleViewModel>();
            return this.View(articles);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var article = await this.articlesService.GetArticleById<DetailArticleVIewModel>(id);

            if (article == null)
            {
                return this.NotFound();
            }

            return this.View(article);
        }

        public IActionResult Create()
        {
            var input = new ArticleInputViewModel();
            return this.View(input);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleInputViewModel article)
        {
            var userId = this.userManager.GetUserId(this.User);
            article.UserId = userId;

            if (!this.ModelState.IsValid)
            {
                return this.View(article);
            }

            var isCreated = await this.articlesService.CreateAsync(article);

            if (!isCreated)
            {
                this.ViewData["Message"] = "Something is wrong. Article can not be created.";
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var userId = this.userManager.GetUserId(this.User);
            var article = await this.articlesService.GetArticleById<DetailArticleVIewModel>(id);

            if (article == null || article.CreatedById != userId)
            {
                return this.Forbid();
            }

            return this.View(article);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.articlesService.DeleteAsync(id, userId);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
