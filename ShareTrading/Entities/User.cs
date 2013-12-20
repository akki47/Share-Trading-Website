namespace ShareTradingModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class User
    {
        public User()
        {
            this.Portfolios = new HashSet<Portfolio>();
            this.TransactionHistories = new HashSet<TransactionHistory>();
        }

        //It should be auto generated
        public long Id { get; set; }
        [Required]
        public long Points { get; set; }
        [Required]
        public long PersonalDetailId { get; set; }
        public long AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual PersonalDetail PersonalDetail { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
