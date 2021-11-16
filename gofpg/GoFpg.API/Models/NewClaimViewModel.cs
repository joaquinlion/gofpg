using GoFpg.API.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoFpg.API.Models
{
    public class NewClaimViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Date of Loss")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime DateOfLoss { get; set; }

        [Display(Name = "Type of Damage")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Damage { get; set; }

        [Display(Name = "Job Scheduled Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime ScheduleDate { get; set; }

        [Display(Name = "Insurance Company Name")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string InsuranceCo { get; set; }

        [Display(Name = "Policy Number")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PolicyNumber { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debes introducir un email válido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Street Adress")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string Address { get; set; }

        [Display(Name = "VIN Picture")]
        public Guid VINImageId { get; set; }

        [Display(Name = "VIN Picture")]
        public string ImageFullPath => VINImageId == Guid.Empty
            ? $"https://localhost:44345/images/noimage.png"
            : $"https://vehicles.blob.core.windows.net/users/{VINImageId}";

        [Display(Name = "VIN Picture")]
        [NotMapped]
        public IFormFile VinImageFile { get; set; }

        [Display(Name = "VIN Number")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string VinNumber { get; set; }

        [Display(Name = "Drivers License Picture")]
        public Guid DLImageId { get; set; }

        [Display(Name = "Drivers License Picture")]
        public string DLImageFullPath => DLImageId == Guid.Empty
            ? $"https://localhost:44345/images/noimage.png"
            : $"https://vehicles.blob.core.windows.net/users/{DLImageId}";

        //[Display(Name = "Drivers License Picture")]
        //public IFormFile DLImageFile { get; set; }

        [Display(Name = "Insurance Card Picture")]
        public Guid InsCardImageId { get; set; }

        [Display(Name = "Insurance Card Picture")]
        public string InsCardImageFullPath => InsCardImageId == Guid.Empty
            ? $"https://localhost:44345/images/noimage.png"
            : $"https://vehicles.blob.core.windows.net/users/{InsCardImageId}";

        //[Display(Name = "Insurance Card Picture")]
        //public IFormFile InsCardImageFile { get; set; }

        //TODO SUBMITTED BY
    }
}
