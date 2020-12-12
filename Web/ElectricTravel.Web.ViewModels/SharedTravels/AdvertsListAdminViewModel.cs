namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System.Collections.Generic;

    public class AdvertsListAdminViewModel : PagingViewModel
    {
        public IEnumerable<AdvertAdminViewModel> Adverts { get; set; }
    }
}
