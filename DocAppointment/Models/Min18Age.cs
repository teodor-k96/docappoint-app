using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocAppointment.Models
{
    public class Min18Age : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var enteredBirthdate = (DateTime)value;

            var age = DateTime.Today.Year - enteredBirthdate.Year; 

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Трябва да имате навършени 18 години!");
        }
    }
}