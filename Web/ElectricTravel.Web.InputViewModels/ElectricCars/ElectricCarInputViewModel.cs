namespace ElectricTravel.Web.InputViewModels.ElectricCars
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;

    public class ElectricCarInputViewModel : BaseElectricCarInputViewModel
    {
        public IEnumerable<KeyValuePair<string, string>> CarTypes { get; set; }
    }
}
