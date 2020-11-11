namespace ElectricTravel.Data.Models.Message
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.User;

    public class ChatMessage : BaseDeletableModel<string>
    {
        [MaxLength(2500)]
        public string Content { get; set; }

        [Required]
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ElectricTravelUser User { get; set; }

        [Required]
        public string ReceiverUsername { get; set; }

        public DateTime SendedOn { get; set; }
    }
}
