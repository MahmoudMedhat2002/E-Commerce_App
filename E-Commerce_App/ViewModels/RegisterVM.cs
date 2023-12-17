using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.ViewModels
{
    public class RegisterVM
    {

		[Display(Name = "Full name")]
		[Required]
		public string FullName { get; set; }

		[Display(Name = "Email")]
        [Required]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

		[Display(Name = "Confirm password")]
		[DataType(DataType.Password)]
		[Required]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
	}
}
