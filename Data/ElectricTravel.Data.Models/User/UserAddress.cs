namespace ElectricTravel.Data.Models.User
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Location;

    public class UserAddress : IDeletableEntity
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ElectricTravelUser User { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
