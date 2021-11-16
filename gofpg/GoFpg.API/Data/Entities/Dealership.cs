using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoFpg.API.Data.Entities
{
    public class Dealership
    {
        public int Id { get; set; }

        [Display(Name = "Dealership")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Dealer { get; set; }

        [Display(Name = "Service Phone Number")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string ServicePhone { get; set; }

        [Display(Name = "Parts Phone Number")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string PartsPhone { get; set; }

        [Display(Name = "Address")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Address { get; set; }
    }
}
