using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using video.Models;
using System.ComponentModel.DataAnnotations;
namespace video.Models
{
    public class isAge18:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            
            if(customer.MembershipTypeId==MembershipType.Unknown || customer.MembershipTypeId==MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if(customer.birthdate==null)
            {
                return new ValidationResult("Enter your Date of Birth");
            }

                var age = DateTime.Now.Year - customer.birthdate.Value.Year;
                return (age>=18) ? ValidationResult.Success :new ValidationResult("You should be over 18 years to become a member");





        }
    }
}