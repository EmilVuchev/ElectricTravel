namespace ElectricTravel.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserAddress
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
