// ReSharper disable VirtualMemberCallInConstructor
namespace ElectricTravel.Data.Models.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Models.Message;
    using ElectricTravel.Data.Models.Multimedia;
    using Microsoft.AspNetCore.Identity;

    public class ElectricTravelUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ElectricTravelUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Cars = new HashSet<UserCar>();
            this.UserAddresses = new HashSet<UserAddress>();
            this.ChatMessages = new HashSet<ChatMessage>();
            this.Groups = new HashSet<UserGroup>();
            this.CarAdverts = new HashSet<CarAdvert>();
            this.SharedTravelAdverts = new HashSet<SharedTravelAdvert>();
            this.FavouritesAdverts = new HashSet<CarAdvert>();
            this.UserRatings = new HashSet<UserRating>();
            this.EvaluatedUsers = new HashSet<UserRating>();
            this.Images = new HashSet<Image>();
        }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsBlocked { get; set; }

        [MaxLength(200)]
        public string ReasonToBeBlocked { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserRating> UserRatings { get; set; }

        [InverseProperty("Assessor")]
        public virtual ICollection<UserRating> EvaluatedUsers { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual ICollection<CarAdvert> CarAdverts { get; set; }

        [InverseProperty("LikedBy")]
        public virtual ICollection<CarAdvert> FavouritesAdverts { get; set; }

        public virtual ICollection<SharedTravelAdvert> SharedTravelAdverts { get; set; }

        public virtual ICollection<ChatMessage> ChatMessages { get; set; }

        public virtual ICollection<UserGroup> Groups { get; set; }

        public virtual ICollection<UserCar> Cars { get; set; }

        public virtual ICollection<UserAddress> UserAddresses { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
