namespace ElectricTravel.Web.InputViewModels.Rates
{
    using System.ComponentModel.DataAnnotations;

    public class PostRateInputModel
    {
        [Required]
        public string UserId { get; set; }

        [Range(1, 5)]
        public double Value { get; set; }
    }
}
