using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyModified.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var customer = (Customer)validationContext.ObjectInstance;

                if (customer.MemberShipTypeId == 1 || customer.MemberShipTypeId == 0)
                return ValidationResult.Success;
               if (customer.BirthDay == null)
                return new ValidationResult("Birthday is required");
            var age = DateTime.Today.Year - customer.BirthDay.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old");

        }
    }

}