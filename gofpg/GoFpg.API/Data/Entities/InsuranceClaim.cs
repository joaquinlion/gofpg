using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GoFpg.API.Data.Entities
{
    public class InsuranceClaim
    {
        public int Id { get; set; }

        [Display(Name = "Repair Order Number")]
        public string RONumber => $"{(Id + 1234) * 3}";

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

        [Display(Name = "VIN Number")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string VinNumber { get; set; }

        [Display(Name = "License Tag")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string Tag { get; set; }

        [Display(Name = "Mileage")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
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

        [Display(Name = "Customer Name")]
        [JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public User User { get; set; }

        //[Display(Name = "Vehicle")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //public Vehicle Vehicle { get; set; }


        //data adicional

        [Display(Name = "VIN Picture")]
        public Guid VINImageId { get; set; }

        [Display(Name = "VIN Picture")]
        public string ImageFullPath => VINImageId == Guid.Empty
            ? $"https://localhost:44345/images/noimage.png"
            : $"https://vehicles.blob.core.windows.net/users/{VINImageId}";

        [Display(Name = "Drivers License Picture")]
        public Guid DLImageId { get; set; }

        [Display(Name = "Drivers License Picture")]
        public string DLImageFullPath => DLImageId == Guid.Empty
            ? $"https://localhost:44345/images/noimage.png"
            : $"https://vehicles.blob.core.windows.net/users/{DLImageId}";

        [Display(Name = "Insurance Card Picture")]
        public Guid InsCardImageId { get; set; }

        [Display(Name = "Insurance Card Picture")]
        public string InsCardImageFullPath => InsCardImageId == Guid.Empty
            ? $"https://localhost:44345/images/noimage.png"
            : $"https://vehicles.blob.core.windows.net/users/{InsCardImageId}";

        //TODO SUBMITTED BY
    }
}
