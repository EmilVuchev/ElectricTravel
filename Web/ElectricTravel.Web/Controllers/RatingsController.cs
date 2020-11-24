namespace ElectricTravel.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.Rates;
    using ElectricTravel.Web.ViewModels.Rates;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : BaseController
    {
        private readonly IRatingService ratingService;

        public RatingsController(IRatingService ratingService)
        {
            this.ratingService = ratingService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostRateResponseModel>> Post(PostRateInputModel input)
        {
            var assessorId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.ratingService.SetRateAsync(input.UserId, assessorId, input.Value);
            var averageRate = this.ratingService.GetAverageRating(input.UserId);
            return new PostRateResponseModel { AverageRate = averageRate };
        }
    }
}
