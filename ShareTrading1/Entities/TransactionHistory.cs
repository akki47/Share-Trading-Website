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
    
    public partial class TransactionHistory
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ShareId { get; set; }
        public int Mode { get; set; }
        public long NumberOfShares { get; set; }
        public decimal PricePerShare { get; set; }
        public decimal ProfitPerShare { get; set; }
    
        public virtual Share Share { get; set; }
        public virtual User User { get; set; }
    }
}
