namespace ShareTradingModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Address : IValidatableObject
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        public string Fax { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            //Write some custom validation logic
            return new List<ValidationResult>();
        }
    }
}
