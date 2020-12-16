namespace ElectricTravel.Data.Models.User
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;

    public class TypeTravel : BaseDeletableModel<int>
    {
        [Required]
        [ForeignKey(nameof(Assessor))]
        public string AssessorId { get; set; }

        public ElectricTravelUser Assessor { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ElectricTravelUser User { get; set; }

        public double Value { get; set; }
    }
}
