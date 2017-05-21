using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieRentalStore.Models.CustomValidation;

namespace MovieRentalStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Please Enter Customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}