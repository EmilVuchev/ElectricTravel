namespace ElectricTravel.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using ElectricTravel.Web.ViewModels.SharedTravels;

    public class SharedTravelHomeListingViewModel
    {
        public IEnumerable<SharedTravelsViewModel> SharedTravels { get; set; }
    }
}
