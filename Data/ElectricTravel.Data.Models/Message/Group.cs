namespace ElectricTravel.Data.Models.Message
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;

    public class Group : BaseDeletableModel<int>
    {
        public Group()
        {
            this.UsersGroups = new HashSet<UserGroup>();
            this.ChatMessages = new HashSet<ChatMessage>();
        }

        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<UserGroup> UsersGroups { get; set; }

        public ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
