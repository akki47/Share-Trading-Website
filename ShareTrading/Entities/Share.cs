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
    
    public partial class Share
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public Nullable<long> StockExchangeId { get; set; }
        public decimal FaceValue { get; set; }
        public long QuantityInitial { get; set; }
        public long QuantityRemaining { get; set; }
    
        public virtual Company Company { get; set; }
    }
}