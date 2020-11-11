namespace ElectricTravel.Web.Controllers
{
    using ElectricTravel.Web.InputViewModels.ElectricCars;
    using Microsoft.AspNetCore.Mvc;

    public class ElectricCarsController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ElectricCarsInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect("/");
        }
    }
}
