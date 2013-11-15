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
    
    public partial class PersonalDetail
    {
        public PersonalDetail()
        {
            this.Companies = new HashSet<Company>();
            this.Users = new HashSet<User>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public long Address1ID { get; set; }
        public Nullable<long> Address2ID { get; set; }
    
        public virtual Address Address1 { get; set; }
        public virtual Address Address2 { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
