using System.ComponentModel.DataAnnotations;

namespace GoFpg.API.Models
{
    public class RecoverPasswordViewModel
    {
        [Required(ErrorMessage = "{0} field is required.")]
        [EmailAddress(ErrorMessage = "Please introduce a valid Email.")]
        public string Email { get; set; }
    }
}
