using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using Appli.Dtos;

namespace Appli.Models.Validations
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance as Customer;
            if (customer is null)
            {
                if (!(validationContext.ObjectInstance is CustomerDto customerDto))
                {
                    return new ValidationResult("Couldn't map CustomerDto to Customer");
                }
                customer = new Customer();
                Mapper.Map(customerDto, customer);
            }

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (!customer.Birthdate.HasValue)
            {
                return new ValidationResult("Birthdate field is required.");
            }

            if (DateTime.Now.Year - customer.Birthdate.Value.Year < 18 )
            {
                return new ValidationResult("Customer should be at least 18 years old to go on membership.");
            }

            return ValidationResult.Success;
        }
    }
}