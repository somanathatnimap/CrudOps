using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MVC_Model
{
    public class SomaValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string Message = value.ToString();
                if(Message.Contains("soma"))
                {
                    return ValidationResult.Success;
                }
            }
                return new ValidationResult("soma not inserted");
        }
    }
}