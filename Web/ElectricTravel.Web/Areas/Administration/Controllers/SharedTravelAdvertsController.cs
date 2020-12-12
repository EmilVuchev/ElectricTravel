namespace ElectricTravel.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.ViewModels.SharedTravels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class SharedTravelAdvertsController : AdministrationController
    {
        private const int ItemsPerPage = 10;
        private readonly ElectricTravelDbContext _context;
        private readonly ISharedTravelsService sharedTravelsService;

        public SharedTravelAdvertsController(
            ElectricTravelDbContext context,
            ISharedTravelsService sharedTravelsService)
        {
            _context = context;
            this.sharedTravelsService = sharedTravelsService;
        }

        // GET: Administration/SharedTravelAdverts
        public async Task<IActionResult> Index(int id = 1)
        {
            var adverts = await this.sharedTravelsService.GetAllAsync<AdvertAdminViewModel>(id);

            if (adverts == null)
            {
                return this.NoContent();
            }

            var viewModel = new AdvertsListAdminViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                AdvertsCount = await this.sharedTravelsService.GetAllAdvertsCount(),
                Adverts = adverts,
            };

            return this.View(viewModel);
        }

        // GET: Administration/SharedTravelAdverts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var sharedTravelAdvert = await _context.SharedTravelAdverts
                .Include(s => s.CreatedBy)
                .Include(s => s.EndDestination)
                .Include(s => s.StartDestination)
                .Include(s => s.Status)
                .Include(s => s.TypeOfTravel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sharedTravelAdvert == null)
            {
                return this.NotFound();
            }

            return this.View(sharedTravelAdvert);
        }

        // GET: Administration/SharedTravelAdverts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var sharedTravelAdvert = await _context.SharedTravelAdverts.FindAsync(id);
            if (sharedTravelAdvert == null)
            {
                return this.NotFound();
            }

            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Id", sharedTravelAdvert.CreatedById);
            ViewData["EndDestinationId"] = new SelectList(_context.Cities, "Id", "Name", sharedTravelAdvert.EndDestinationId);
            ViewData["StartDestinationId"] = new SelectList(_context.Cities, "Id", "Name", sharedTravelAdvert.StartDestinationId);
            ViewData["StatusId"] = new SelectList(_context.SharedTravelStatus, "Id", "Name", sharedTravelAdvert.StatusId);
            ViewData["TypeOfTravelId"] = new SelectList(_context.TypeTravels, "Id", "Name", sharedTravelAdvert.TypeOfTravelId);
            return this.View(sharedTravelAdvert);
        }

        // POST: Administration/SharedTravelAdverts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StartDateAndTime,Seats,SmokeRestriction,PlaceForLuggage,WithReturnTrip,Description,TypeOfTravelId,StartDestinationId,EndDestinationId,StatusId,CreatedById,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] SharedTravelAdvert sharedTravelAdvert)
        {
            if (id != sharedTravelAdvert.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    _context.Update(sharedTravelAdvert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.SharedTravelAdvertExists(sharedTravelAdvert.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectToAction(nameof(this.Index));
            }

            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Id", sharedTravelAdvert.CreatedById);
            ViewData["EndDestinationId"] = new SelectList(_context.Cities, "Id", "Name", sharedTravelAdvert.EndDestinationId);
            ViewData["StartDestinationId"] = new SelectList(_context.Cities, "Id", "Name", sharedTravelAdvert.StartDestinationId);
            ViewData["StatusId"] = new SelectList(_context.SharedTravelStatus, "Id", "Name", sharedTravelAdvert.StatusId);
            ViewData["TypeOfTravelId"] = new SelectList(_context.TypeTravels, "Id", "Name", sharedTravelAdvert.TypeOfTravelId);
            return this.View(sharedTravelAdvert);
        }

        // GET: Administration/SharedTravelAdverts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var sharedTravelAdvert = await _context.SharedTravelAdverts
                .Include(s => s.CreatedBy)
                .Include(s => s.EndDestination)
                .Include(s => s.StartDestination)
                .Include(s => s.Status)
                .Include(s => s.TypeOfTravel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sharedTravelAdvert == null)
            {
                return this.NotFound();
            }

            return this.View(sharedTravelAdvert);
        }

        // POST: Administration/SharedTravelAdverts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sharedTravelAdvert = await _context.SharedTravelAdverts.FindAsync(id);
            _context.SharedTravelAdverts.Remove(sharedTravelAdvert);
            await _context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool SharedTravelAdvertExists(string id)
        {
            return _context.SharedTravelAdverts.Any(e => e.Id == id);
        }
    }
}
