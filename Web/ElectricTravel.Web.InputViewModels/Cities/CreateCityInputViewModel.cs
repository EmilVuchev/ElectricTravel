namespace ElectricTravel.Web.InputViewModels.Cities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateCityInputViewModel
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        public int RegionId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Regions { get; set; }
    }
}
