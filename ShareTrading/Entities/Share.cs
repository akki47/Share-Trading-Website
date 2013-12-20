namespace ShareTradingModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Share:IValidatableObject
    {
        public Share()
        {
            this.Portfolios = new HashSet<Portfolio>();
            this.TransactionHistories = new HashSet<TransactionHistory>();
        }

        public long Id { get; set; }

        [Required]
        public long CompanyId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Name should not be less than 5 and more than 30 characters.")]
        public string Name { get; set; }
        public Nullable<long> StockExchangeId { get; set; }
        [Required]
        public decimal FaceValue { get; set; }
        [Required]
        public long QuantityInitial { get; set; }
        [Required]
        public long QuantityRemaining { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}
