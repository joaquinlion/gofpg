using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoFpg.API.Models
{
    public class RecoverPasswordViewModel
    {
        [Required(ErrorMessage = "{0} field is required.")]
        [EmailAddress(ErrorMessage = "Please introduce a valid Email.")]
        public string Email { get; set; }
    }
}
