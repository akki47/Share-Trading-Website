//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class User : Account
    {
        public User()
        {
            this.Portfolios = new HashSet<Portfolio>();
            this.TransactionHistories = new HashSet<TransactionHistory>();
        }
    
        public long Points { get; set; }
        public long PersonalDetailId { get; set; }
    
        public virtual PersonalDetail PersonalDetail { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
