using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyTrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Display (Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
       
        public string City { get; set; }
        public string State { get; set; }
        public int  ZipCode { get; set; }
        [DisplayName("Chose A Day Of The Week")]
        public string Day { get; set; }
        [DisplayName ("Start Date for Pick-up")]
        public string StartDay { get; set; }
        [DisplayName("End Date of Pick-ups")]
        public string EndDate { get; set; }
        [DisplayName("Extra Added Pick-up")]
        public string ExtraPick { get; set; }
        public double Balance { get; set; }
        public bool PickConfirmed { get; set; }

    }
}