using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoFpg.API.Data.Entities
{
    public class InsuranceClaim
    {
        public int Id { get; set; }

        [Display(Name = "Date of Loss")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime DateOfLoss { get; set; }

        [Display(Name = "Type of Damage")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Damage { get; set; }

        [Display(Name = "Job Scheduled Date")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime ScheduleDate { get; set; }

        [Display(Name = "Insurance Company Name")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string InsuranceCo { get; set; }

        [Display(Name = "Policy Number")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PolicyNumber { get; set; }

        //[Display(Name = "Usuario")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //public User User { get; set; }

        [Display(Name = "VIN")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehicle Vehicle { get; set; }

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
