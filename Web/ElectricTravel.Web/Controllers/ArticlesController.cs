namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Data;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Mvc;

    public class ArticlesController : Controller
    {
        private readonly ElectricTravelDbContext _context;
        private readonly IArticlesService articlesService;

        public ArticlesController(
            ElectricTravelDbContext context,
            IArticlesService articlesService)
        {
            _context = context;
            this.articlesService = articlesService;
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

        // GET: Articles/Create
        //public IActionResult Create()
        //{
        //    this.ViewData["SourceId"] = new SelectList(_context.Sources, "Id", "Name");
        //    this.ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
        //    return this.View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("Title,Content,Path,SourceId,UserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Article article)
        //{
        //    if (this.ModelState.IsValid)
        //    {
        //        _context.Add(article);
        //        await _context.SaveChangesAsync();
        //        return this.RedirectToAction(nameof(this.Index));
        //    }
        //    this.ViewData["SourceId"] = new SelectList(_context.Sources, "Id", "Name", article.SourceId);
        //    this.ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", article.UserId);
        //    return this.View(article);
        //}

        // GET: Articles/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return this.NotFound();
        //    }

        //    var article = await _context.Articles
        //        .Include(a => a.Source)
        //        .Include(a => a.User)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (article == null)
        //    {
        //        return this.NotFound();
        //    }

        //    return this.View(article);
        //}

        // POST: Articles/Delete/5
        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var article = await _context.Articles.FindAsync(id);
        //    _context.Articles.Remove(article);
        //    await _context.SaveChangesAsync();
        //    return this.RedirectToAction(nameof(this.Index));
        //}

        //private bool ArticleExists(int id)
        //{
        //    return _context.Articles.Any(e => e.Id == id);
        //}
    }
}
