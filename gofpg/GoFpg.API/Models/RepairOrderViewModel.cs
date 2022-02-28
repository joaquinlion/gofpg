using GoFpg.API.Data.Entities;
using GoFpg.API.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoFpg.API.Models
{
    public class RepairOrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Bill To")]
        public string BillTo { get; set; }
        [Display(Name = "Policy Number")]
        public string PolicyNumber { get; set; }

        [Display(Name = "Insurance Card Pic")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile PolicyImageFile { get; set; }

        [Display(Name = "Insurance Card Picture")]
        public Guid PolicyImageId { get; set; }

        [Display(Name = "Insurance Card Picture")]
        public string PolicyImageFullPath => PolicyImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/stories/{PolicyImageId}";

        [Display(Name = "Has Referral")]
        public bool HasReferral { get; set; }

        [Display(Name = "Referral Number")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string ReferralNumber { get; set; }

        [Display(Name = "Part Number")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PartNumber { get; set; }

        [Display(Name = "Parts Available")]
        public bool ArePartsAvailable { get; set; }

        [Display(Name = "Has Approval")]
        public bool HasApproval { get; set; }

        [Display(Name = "Part Invoice Pic")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile PartImageFile { get; set; }

        [Display(Name = "Part Invoice")]
        public Guid InvoiceImageId { get; set; }

        [Display(Name = "Part Invoice")]
        public string InvoiceImageFullPath => InvoiceImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/stories/{InvoiceImageId}";

        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledDate { get; set; }

        [Display(Name = "Is Scheduled")]
        public bool IsScheduled { get; set; }

        [Display(Name = "Installer Name")]
        public string InstallerName { get; set; }

        [Display(Name = "Procedure")]
        public string Procedure { get; set; }

        [Display(Name = "Tag Pic")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile TagImageFile { get; set; }

        [Display(Name = "Tag Picture")]
        public Guid TagImageId { get; set; }

        [Display(Name = "Tag Picture")]
        public string TagImageFullPath => TagImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/stories/{TagImageId}";

        [Display(Name = "Damage Pic")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile DamageImageFile { get; set; }

        [Display(Name = "Damage Picture")]
        public Guid DamageImageId { get; set; }

        [Display(Name = "Damage Picture")]
        public string DamageImageFullPath => DamageImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/stories/{DamageImageId}";

        [Display(Name = "Full Glass Pic")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile FullGlassImageFile { get; set; }

        [Display(Name = "Full Glass Picture")]
        public Guid FullDamageImageId { get; set; }

        [Display(Name = "Full Glass Picture")]
        public string FullDamageImageFullPath => FullDamageImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/stories/{FullDamageImageId}";

        [Display(Name = "Vin Pic")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile VinImageFile { get; set; }

        [Display(Name = "VIN Plate Picture")]
        public Guid VinImageId { get; set; }

        [Display(Name = "VIN Plate Picture")]
        public string VinImageFullPath => VinImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/stories/{VinImageId}";

        [Display(Name = "Interior Pic")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile InteriorImageFile { get; set; }

        [Display(Name = "Interior Picture")]
        public Guid InteriorImageId { get; set; }

        [Display(Name = "Interior Picture")]
        public string InteriorImageFullPath => InteriorImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/stories/{InteriorImageId}";

        [Display(Name = "Has Pictures")]
        public bool HasPictures { get; set; }

        [Display(Name = "Has Signature")]
        public bool HasSignature { get; set; }

        [Display(Name = "Mileage")]
        public int Mileage { get; set; }

        [Display(Name = "Install Date")]
        public DateTime InstallDate { get; set; }

        [Display(Name = "Port Work Pic")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile InstalledImageFile { get; set; }

        [Display(Name = "Post Work Picture")]
        public Guid InstalledImageId { get; set; }

        [Display(Name = "Post Work Picture")]
        public string InstalledImageFullPath => InstalledImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/stories/{InstalledImageId}";

        [Display(Name = "Part Installed Pic")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile Installed2ImageFile { get; set; }

        [Display(Name = "Part Installed Picture")]
        public Guid Installed2ImageId { get; set; }

        [Display(Name = "Part Installed Picture")]
        public string Installed2ImageFullPath => Installed2ImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/stories/{Installed2ImageId}";

        [Display(Name = "Is Installed")]
        public bool IsInstalled { get; set; }

        [Display(Name = "Has Calibration")]
        public bool HasCalibration { get; set; }

        [Display(Name = "Calibration Report")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile ReportFile { get; set; }

        [Display(Name = "Calibration Report")]
        public Guid ReportId { get; set; }

        [Display(Name = "Calibration Report")]
        public string ReportFullPath => ReportId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/stories/{ReportId}";

        [Display(Name = "Calibration Done")]
        public bool CalibrationDone { get; set; }

        [Display(Name = "Signed RO")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile SignedROFile { get; set; }

        [Display(Name = "Signed RO")]
        public Guid SignedROImageId { get; set; }

        [Display(Name = "Signed RO")]
        public string SignedROImageFullPath => SignedROImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/stories/{SignedROImageId}";
    }
}
