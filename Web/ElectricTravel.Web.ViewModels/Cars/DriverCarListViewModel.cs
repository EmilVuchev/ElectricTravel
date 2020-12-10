namespace ElectricTravel.Web.ViewModels.Cars
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Web.ViewModels.SharedTravels;

    public class DriverCarListViewModel
    {
        public DriverInfoViewModel Driver { get; set; }

        [Display(Name = "Cars: ")]
        public IEnumerable<DriverCarViewModel> Cars { get; set; }
    }
}
