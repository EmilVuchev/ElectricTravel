using System.ComponentModel.DataAnnotations;

namespace ElectricTravel.Web.InputViewModels.Rates
{
    public class PostRateInputModel
    {
        [Required]
        public string UserId { get; set; }

        [Range(1, 5)]
        public double Value { get; set; }
    }
}
