using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFpg.API.Models
{
    public class NewClaimViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Repair Order Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime RODate { get; set; }

        [Display(Name = "Date of Loss")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime DateOfLoss { get; set; }

        [Display(Name = "Type of Damage")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Damage { get; set; }

        [Display(Name = "Repair Description")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Repair { get; set; }

        [Display(Name = "Job Scheduled Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime ScheduleDate { get; set; }

        //scheduletime

        [Display(Name = "Insurance Company Name")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string InsuranceCo { get; set; }

        [Display(Name = "Policy Number")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PolicyNumber { get; set; }

        [Display(Name = "Referral Number")]
        public string ReferralNumber { get; set; }

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
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Street Adress")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string Address { get; set; }

        [Display(Name = "Apt, Ste, #")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string Zip { get; set; }

        [Display(Name = "State")]
        [MaxLength(16, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string State { get; set; }

        [Display(Name = "Alternate Contact")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string AltContactName { get; set; }

        [Display(Name = "Alternate Phone Number")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string AltPhoneNumber { get; set; }

        [Display(Name = "VIN Number")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string VinNumber { get; set; }

        [Display(Name = "License Tag")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(7, MinimumLength = 4, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string Tag { get; set; }

        [Display(Name = "Mileage")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string Mileage { get; set; }

        //TODO SUBMITTED BY
    }
}
