using System.ComponentModel.DataAnnotations;

namespace GoFpg.API.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please introduce a valid Email.")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(6, ErrorMessage = "{0} field must have at least {1} characters.")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
