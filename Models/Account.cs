using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMVCApplication.Models
{
    /*public class Account
    {
        public string Name { get; set; }
        public string Password { get; set;}
    }*/
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
