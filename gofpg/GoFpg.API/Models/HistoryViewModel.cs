using System;
using System.ComponentModel.DataAnnotations;

namespace GoFpg.API.Models
{
    public class HistoryViewModel
    {
        public int VehicleId { get; set; }

        //[Display(Name = "Repair Order Number")]
        //public string RONumber => $"{(VehicleId + 1234) * 3}";

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

        [Display(Name = "Job Scheduled Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime ScheduleTime { get; set; }

        [Display(Name = "Insurance Company Name")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string InsuranceCo { get; set; }

        [Display(Name = "Policy Number")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PolicyNumber { get; set; }

        [Display(Name = "Mileage")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string Mileage { get; set; }

        [Display(Name = "Referral Number")]
        public string ReferralNumber { get; set; }

        [Display(Name = "Street Adress")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string AltAddress { get; set; }

        [Display(Name = "Apt, Ste, #")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string AltAddress2 { get; set; }

        [Display(Name = "City")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string AltCity { get; set; }

        [Display(Name = "Zip Code")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string AltZip { get; set; }

        [Display(Name = "State")]
        [MaxLength(16, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string AltState { get; set; }

        [Display(Name = "Alternate Contact")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string AltContactName { get; set; }

        [Display(Name = "Alternate Phone Number")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string AltPhoneNumber { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
    }
}
