namespace ElectricTravel.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ElectricCarsController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
