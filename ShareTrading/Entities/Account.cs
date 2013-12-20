namespace ShareTradingModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Account:IValidatableObject
    {        
        [ScaffoldColumn(false)]
        public long Id { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "User name should not be less than 5 and more than 30 characters.")]
        public string UserName { get; set; }

        [Required]
        public string SpecialQuestion { get; set; }

        [Required]
        public string Answer { get; set; }

        public RoleType Role { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            //if (string.Compare(this.UserName, this.Password, true) == 0)
            //{
            //    yield return new ValidationResult("UserName and Password can not be same.");
            //}
            return new List<ValidationResult>();
        }
    }
}
