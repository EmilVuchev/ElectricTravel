namespace ElectricTravel.Web.Areas.Administration.Controllers
{
    using ElectricTravel.Common;
    using ElectricTravel.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
