using System.ComponentModel.DataAnnotations;

namespace GoFpg.API.Models
{
    public class AddUserViewModel : EditUserViewModel
    {
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please introduce a valid Email.")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(6, ErrorMessage = "{0} must have at least {1} characters.")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "{0} field is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "{0} must have at least {1} characters.")]
        [Compare("Password", ErrorMessage = "The password fields do not match each other.")]
        public string PasswordConfirm { get; set; }
    }
}
