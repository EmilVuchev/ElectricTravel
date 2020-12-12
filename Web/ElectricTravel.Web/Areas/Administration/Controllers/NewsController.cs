namespace ElectricTravel.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class NewsController : AdministrationController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        ////public async Task<IActionResult> Details(int id)
        ////{

        ////}

        ////[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        ////public async Task<IActionResult> Create()
        ////{

        ////}

        ////[HttpPost]
        ////[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        ////public async Task<IActionResult> Create()
        ////{

        ////}

        ////[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        ////public async Task<IActionResult> Edit()
        ////{

        ////}

        ////[HttpPost]
        ////[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        ////public async Task<IActionResult> Edit()
        ////{

        ////}

        ////[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        ////public async Task<IActionResult> Delete()
        ////{

        ////}
    }
}
