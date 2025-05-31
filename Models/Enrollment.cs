//using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMVCApplication.Models
{
    public class Enrollment
    {
        /*[Key]
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

        [Required(ErrorMessage = "Subject Code Required!")]
        [DisplayName("Subject Code")]
        public string? SFSUBJCODE { get; set; }

        [Required(ErrorMessage = "Description Required!")]
        [DisplayName("Subject Description")]
        public string? SFSUBJDESC { get; set; }

        [Required(ErrorMessage = "Units Required!")]
        [DisplayName("Subject Units")]
        public int? SFSUBJUNITS { get; set; }
        [Required(ErrorMessage = "Offering Required!")]
        [DisplayName("Subject Offering")]
        public string? SFSUBJREGOFRNG { get; set; }

        [Required(ErrorMessage = "Category Required!")]
        [DisplayName("Subject Category")]
        public string? SFSUBJCATEGORY { get; set; }

        [Required(ErrorMessage = "Course Code Required!")]
        [DisplayName("Course Code")]
        public string? SFSUBJCOURSECODE { get; set; }
        [DisplayName(" Requisite Code")]
        public string? SFSUBJREQ { get; set; }

        [DisplayName("Subject Requisite Code")]
        public string? SFSUBJCODEREQ { get; set; }

        [Required(ErrorMessage = "Curriculum Code Required!")]
        [DisplayName("Curriculum Code")]
        public string? SFSUBJCURRICULUMCOURSECODE { get; set; }

        [DisplayName("Status")]
        public string? SFSUBJECTSTATUS { get; set; }

        [Required(ErrorMessage = "Edp code Required!")]
        [DisplayName("Subject Edp Code")]
        public string? SSFEDPCODE { get; set; }
        [Required(ErrorMessage = "Subject code Required!")]
        [DisplayName("Subject Code")]
        public string? SSFSUBJCODE { get; set; }

        [Required(ErrorMessage = "Start Time Required!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DisplayName("Start Time")]
        public DateTime? SSFSTARTTIME { get; set; }

        [Required(ErrorMessage = "End time Required!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DisplayName("End Time")]
        public DateTime? SSFENDTIME { get; set; }

        [Required(ErrorMessage = "Days Required!")]
        [DisplayName("Days")]
        public string? SSFDAYS { get; set; }
        [Required(ErrorMessage = "Room  Required!")]
        [DisplayName("Room")]
        public string? SSFROOM { get; set; }
        [Required(ErrorMessage = "Subject Max Size Required!")]
        [DisplayName("Subject Max Size")]
        public string? SSFMAXSIZE { get; set; }
        [Required(ErrorMessage = "Class max size Required!")]
        [DisplayName("Class Max Size")]
        public string? SSFCLASSSIZE { get; set; }
        [Required(ErrorMessage = "Satus Required!")]
        [DisplayName("Subject Status")]
        public string? SSFSTATUS { get; set; }
        [Required(ErrorMessage = "Invalid Input!")]
        [DisplayName("Am/Pm")]
        public string? SSFXM { get; set; }
        [Required(ErrorMessage = "Section Required!")]
        [DisplayName("Section")]
        public string? SSFSECTION { get; set; }
        [Required(ErrorMessage = "Year Required!")]
        [DisplayName("School Year")]
        public string? SSFSCHOOLYEAR { get; set; }*/

        [Key]
        [Required(ErrorMessage = "Enrollment ID Required!")]
        [DisplayName("Enrollment ID")]
        public string? EnrollmentID { get; set; }

        [Required(ErrorMessage = "Student ID Required!")]
        [DisplayName("Student ID")]
        public string? STFSTUDID { get; set; }

        [Required(ErrorMessage = "Subject Code Required!")]
        [DisplayName("Subject Code")]
        public string? SFSUBJCODE { get; set; }
        [Required(ErrorMessage = "Subject Code Required!")]
        [DisplayName("Subject S Code")]
        public string? SSFSUBJCODE { get; set; }

        [Required(ErrorMessage = "Subject Schedule EDP Code Required!")]
        [DisplayName("Subject Schedule EDP Code")]
        public string? SSFEDPCODE { get; set; }

        [Required(ErrorMessage = "Enrollment Date Required!")]
        [DisplayName("Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [DisplayName("Grade")]
        public string? Grade { get; set; }

        [DisplayName("Status")]
        public string? EnrollmentStatus { get; set; }

        [Required(ErrorMessage = "Year Required!")]
        [DisplayName("School Year")]
        public string? SSFSCHOOLYEAR { get; set; }
        [Required(ErrorMessage = "Start Time Required!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DisplayName("Start Time")]
        public DateTime? SSFSTARTTIME { get; set; }

        [Required(ErrorMessage = "End time Required!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DisplayName("End Time")]
        public DateTime? SSFENDTIME { get; set; }

        [Required(ErrorMessage = "Days Required!")]
        [DisplayName("Days")]
        public string? SSFDAYS { get; set; }
        [Required(ErrorMessage = "Room  Required!")]
        [DisplayName("Room")]
        public string? SSFROOM { get; set; }
        [Required(ErrorMessage = "Subject Max Size Required!")]
        [DisplayName("Subject Max Size")]
        public string? SSFMAXSIZE { get; set; }
        [Required(ErrorMessage = "Class max size Required!")]
        [DisplayName("Class Max Size")]
        public string? SSFCLASSSIZE { get; set; }
        [Required(ErrorMessage = "Satus Required!")]
        [DisplayName("Subject Status")]
        public string? SSFSTATUS { get; set; }
        [Required(ErrorMessage = "Invalid Input!")]
        [DisplayName("Am/Pm")]
        public string? SSFXM { get; set; }
        [Required(ErrorMessage = "Section Required!")]
        [DisplayName("Section")]
        public string? SSFSECTION { get; set; }

        // Navigation properties to establish relationships
        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
        public SubjectSchedule? SubjectSchedule { get; set; }
    }
}
