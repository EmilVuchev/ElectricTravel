namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System.Collections.Generic;

    public class AdvertsListViewModel : PagingViewModel
    {
        public bool IsUserAdverts { get; set; }

        public IEnumerable<SharedTravelsViewModel> Adverts { get; set; }
    }
}
