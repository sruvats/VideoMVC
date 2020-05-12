using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace video.Models
{
    public class Customer
    {
        public int id { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "Please provide a Name")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        [isAge18]
        public DateTime? birthdate { get; set; }
    }
}