using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMVCApplication.Models
{
    public class SubjectSchedule
    {
        [Key]
        [Required(ErrorMessage ="Edp code Required!")]
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
        public string? SSFSCHOOLYEAR { get; set; }
        

    }
}
