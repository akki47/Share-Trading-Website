namespace ShareTradingModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class TransactionHistory:IValidatableObject
    {
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }
        [Required]
        public long ShareId { get; set; }
        [Required]
        public int Mode { get; set; }
        [Required]
        public long NumberOfShares { get; set; }
        [Required]
        public decimal PricePerShare { get; set; }
        [Required]
        public decimal ProfitPerShare { get; set; }
    
        public virtual Share Share { get; set; }
        public virtual User User { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
