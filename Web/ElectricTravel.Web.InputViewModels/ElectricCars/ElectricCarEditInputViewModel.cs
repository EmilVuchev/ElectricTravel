namespace ElectricTravel.Web.InputViewModels.ElectricCars
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ElectricCarEditInputViewModel : BaseElectricCarInputViewModel
    {
        public int Id { get; set; }

        ////[Display(Name = "Make")]
        ////public string MakeName { get; set; }

        ////[Display(Name = "Model")]
        ////public string ModelName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CarTypes { get; set; }
    }
}
