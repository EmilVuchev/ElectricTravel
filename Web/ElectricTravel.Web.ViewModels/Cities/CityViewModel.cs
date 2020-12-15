namespace ElectricTravel.Web.ViewModels.Cities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Services.Mapping;

    public class CityViewModel : CityForKeyValuePairViewModel, IMapFrom<City>
    {
        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Deleted On")]
        public DateTime DeletedOn { get; set; }

        [Display(Name = "Region")]
        public string RegionName { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }
    }
}
