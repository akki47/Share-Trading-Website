namespace ShareTradingModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PersonalDetail : IValidatableObject
    {
        public PersonalDetail()
        {
            this.Companies = new HashSet<Company>();
            this.Users = new HashSet<User>();
        }

        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Name should not be less than 5 and more than 30 characters.")]
        public string Name { get; set; }

        [Required]
        public long Address1Id { get; set; }
        public Nullable<long> Address2Id { get; set; }

        public virtual Address Address1 { get; set; }
        public virtual Address Address2 { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<User> Users { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            //Write some custom validation logic
            return new List<ValidationResult>();
        }
    }
}
