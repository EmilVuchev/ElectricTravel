namespace ElectricTravel.Web.ViewModels.SharedTravels
{
    using System.Collections.Generic;

    public class AdvertsListViewModel : PagingViewModel
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public bool IsUserAdverts { get; set; }

        public IEnumerable<SharedTravelsViewModel> Adverts { get; set; }
    }
}
