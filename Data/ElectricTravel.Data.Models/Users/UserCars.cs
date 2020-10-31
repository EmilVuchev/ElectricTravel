namespace ElectricTravel.Data.Models.Users
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserCars
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
