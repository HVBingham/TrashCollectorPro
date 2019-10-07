using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyTrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set;}
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public int ZipCode { get; set; }
        [Display(Name ="Confirm Pick Up")]
        public bool PickUpConfimation { get; set; }
    }
}