using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTest.Models
    {
    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    sealed public class DeferValidation: ValidationAttribute
        {
        object reference { get; set; }
        string propertyname { get; set; }

        public DeferValidation( Type refer, string prop)
            {
            reference = Activator.CreateInstance(refer);
            propertyname = prop;
            }

        public DeferValidation(Type refer)
            {
            reference = Activator.CreateInstance(refer);
            }

        protected override ValidationResult IsValid (object value, ValidationContext valcon)
            {
            ValidationContext context = new ValidationContext(reference);
            List<ValidationResult> valres = new List<ValidationResult>();
            if (propertyname != null)
                {
                context.MemberName = propertyname;
                Validator.TryValidateProperty(value, context, valres);
                }

            else
                {
                Validator.TryValidateObject(value, context, valres);
                }
            return valres.FirstOrDefault();
            }
        }
    }