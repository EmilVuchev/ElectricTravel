namespace ElectricTravel.Web.InputViewModels.SharedTravel
{
    using System.ComponentModel.DataAnnotations;

    public class SharedTravelEditInputViewModel : BaseSharedTravelInputViewModel
    {
        [Display(Name = "Is Approved")]
        public bool IsApproved { get; set; }

        public string Id { get; set; }
    }
}
