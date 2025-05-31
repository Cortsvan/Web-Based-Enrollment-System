//using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMVCApplication.Models
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage = "ID No.Required!")]
        [DisplayName("Student ID")]
        public string? STFSTUDID { get; set; }
        [Required(ErrorMessage = "Last name Required!")]
        [DisplayName("Last Name")]
        public string? STFSTUDLNAME { get; set; }
        [Required(ErrorMessage = "First name Required!")]
        [DisplayName("First Name")]
        public string? STFSTUDFNAME { get; set; }
        [Required(ErrorMessage = "Middle name Required!")]
        [DisplayName("Middle Name")]
        public string? STFSTUDMNAME { get; set; }
        [Required(ErrorMessage = "Course Required!")]
        [DisplayName("Course")]
        public string? STFSTUDCOURSE { get; set; }
        [Required(ErrorMessage = "Year Required!")]
        [DisplayName("Year")]
        public int? STFSTUDYEAR { get; set; }
        [Required(ErrorMessage = "Remarks Required!")]
        [DisplayName("Remarks")]
        public string? STFSTUDREMARKS { get; set; }
       
        [DisplayName("Status")]
        public string? STFSTUDSTATUS { get; set; }
    } 
   
    }
    

