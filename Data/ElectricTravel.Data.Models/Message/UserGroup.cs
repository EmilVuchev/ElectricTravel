namespace ElectricTravel.Data.Models.Message
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.User;

    public class UserGroup : IDeletableEntity
    {
        [Required]
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        public Group Group { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ElectricTravelUser User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
