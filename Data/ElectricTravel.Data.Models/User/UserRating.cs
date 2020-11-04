namespace ElectricTravel.Data.Models.User
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;

    public class UserRating : BaseModel<int>
    {
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ElectricTravelUser User { get; set; }

        public int Rating { get; set; }
    }
}
