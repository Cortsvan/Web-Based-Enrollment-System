using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMVCApplication.Models
{
    public class Subject
    {
        [Key]
        [Required(ErrorMessage = "Subject Code Required!")]
        [DisplayName("Subject Code")] 
        public string? SFSUBJCODE { get; set; }

        [Required(ErrorMessage = "Description Required!")]
        [DisplayName("Subject Description")] 
        public string? SFSUBJDESC { get; set; }

        [Required(ErrorMessage = "Units Required!")]
        [DisplayName("Subject Units")]
        public int? SFSUBJUNITS { get; set; }
        [Required (ErrorMessage = "Offering Required!")]
        [DisplayName("Subject Offering")]
        public string? SFSUBJREGOFRNG { get; set; }

        [Required (ErrorMessage = "Category Required!")]
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

    }
}
