﻿using System;
using System.ComponentModel.DataAnnotations;
using Appli.Models.Validations;

namespace Appli.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }

        public void UpdateModel(Customer input)
        {
            Name = input.Name;
            IsSubscribedToNewsletter = input.IsSubscribedToNewsletter;
            MembershipTypeId = input.MembershipTypeId;
            Birthdate = input.Birthdate;
        }
    }
}