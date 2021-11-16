using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoFpg.API.Data.Entities
{
    public class InsuranceCompany
    {
        public int Id { get; set; }

        [Display(Name = "Insurance Company")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string InsCompany { get; set; }

        [Display(Name = "Phone Number")]
        //[RegularExpression(@"[a-zA-Z]{3}[0-9]{2}[a-zA-Z0-9]", ErrorMessage = "Formato de placa incorrecto.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string InsCoPhone { get; set; }
    }
}
