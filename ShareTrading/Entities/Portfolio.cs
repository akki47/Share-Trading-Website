namespace ShareTradingModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class Portfolio : IValidatableObject
    {
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public long ShareId { get; set; }
        [Required]
        public System.DateTime DateBought { get; set; }
        [Required]
        public decimal AveragePrice { get; set; }

        public virtual Share Share { get; set; }
        public virtual User User { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}
