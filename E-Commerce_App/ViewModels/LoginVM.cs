using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email")]
        [Required]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
