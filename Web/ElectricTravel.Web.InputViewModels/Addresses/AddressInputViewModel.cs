namespace ElectricTravel.Web.InputViewModels.Addresses
{
    using System.ComponentModel.DataAnnotations;

    public class AddressInputViewModel
    {
        [Required]
        [MaxLength(30)]
        public string Street { get; set; }

        [Required]
        [MaxLength(30)]
        public string District { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }
    }
}
