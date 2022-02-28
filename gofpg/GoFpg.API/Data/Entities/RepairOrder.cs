using System;
using System.ComponentModel.DataAnnotations;

namespace GoFpg.API.Data.Entities
{
    public class RepairOrder
    {
        public int Id { get; set; }

        [Display(Name = "Bill To")]
        public string BillTo { get; set; }

        [Display(Name = "Policy Number")]
        public string PolicyNumber { get; set; }

        [Display(Name = "Insurance Card Picture")]
        public Guid PolicyImageId { get; set; }

        [Display(Name = "Insurance Card Picture")]
        public string PolicyImageFullPath => PolicyImageId == Guid.Empty
            ? $"https://localhost:44320/images/noimage.png"
            : $"https://gofpgapistorage.blob.core.windows.net/stories/{PolicyImageId}";

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

        [Display(Name = "Part Invoice")]
        public Guid InvoiceImageId { get; set; }

        [Display(Name = "Part Invoice")]
        public string InvoiceImageFullPath => InvoiceImageId == Guid.Empty
            ? $"https://localhost:44320/images/noimage.png"
            : $"https://gofpgapistorage.blob.core.windows.net/stories/{InvoiceImageId}";

        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledDate { get; set; }

        [Display(Name = "Is Scheduled")]
        public bool IsScheduled { get; set; }

        [Display(Name = "Installer Name")]
        public string InstallerName { get; set; }

        [Display(Name = "Procedure")]
        public string Procedure { get; set; }

        //[Display(Name = "Tag Picture")]
        //public Guid TagImageId { get; set; }

        //[Display(Name = "Tag Picture")]
        //public string TagImageFullPath => TagImageId == Guid.Empty
        //    ? $"https://localhost:44320/images/noimage.png"
        //    : $"https://gofpgapistorage.blob.core.windows.net/stories/{TagImageId}";

        //[Display(Name = "Damage Picture")]
        //public Guid DamageImageId { get; set; }

        //[Display(Name = "Damage Picture")]
        //public string DamageImageFullPath => DamageImageId == Guid.Empty
        //    ? $"https://localhost:44320/images/noimage.png"
        //    : $"https://fpglass.blob.core.windows.net/vehicles/{DamageImageId}";

        //[Display(Name = "Full Glass Picture")]
        //public Guid FullDamageImageId { get; set; }

        //[Display(Name = "Full Glass Picture")]
        //public string FullDamageImageFullPath => FullDamageImageId == Guid.Empty
        //    ? $"https://localhost:44320/images/noimage.png"
        //    : $"https://gofpgapistorage.blob.core.windows.net/stories/{FullDamageImageId}";

        //[Display(Name = "VIN Plate Picture")]
        //public Guid VinImageId { get; set; }

        //[Display(Name = "VIN Plate Picture")]
        //public string VinImageFullPath => VinImageId == Guid.Empty
        //    ? $"https://localhost:44320/images/noimage.png"
        //    : $"https://gofpgapistorage.blob.core.windows.net/stories/{VinImageId}";

        //[Display(Name = "Interior Picture")]
        //public Guid InteriorImageId { get; set; }

        //[Display(Name = "Interior Picture")]
        //public string InteriorImageFullPath => InteriorImageId == Guid.Empty
        //    ? $"https://localhost:44320/images/noimage.png"
        //    : $"https://gofpgapistorage.blob.core.windows.net/stories/{InteriorImageId}";

        [Display(Name = "Has Pictures")]
        public bool HasPictures { get; set; }

        [Display(Name = "Has Signature")]
        public bool HasSignature { get; set; }

        [Display(Name = "Mileage")]
        public int Mileage { get; set; }

        [Display(Name = "Install Date")]
        public DateTime InstallDate { get; set; }

        //[Display(Name = "Post Work Picture")]
        //public Guid InstalledImageId { get; set; }

        //[Display(Name = "Post Work Picture")]
        //public string InstalledImageFullPath => InstalledImageId == Guid.Empty
        //    ? $"https://localhost:44320/images/noimage.png"
        //    : $"https://gofpgapistorage.blob.core.windows.net/stories/{InstalledImageId}";

        //[Display(Name = "Work Complete Picture")]
        //public Guid Installed2ImageId { get; set; }

        //[Display(Name = "Work Complete Picture")]
        //public string Installed2ImageFullPath => Installed2ImageId == Guid.Empty
        //    ? $"https://localhost:44320/images/noimage.png"
        //    : $"https://gofpgapistorage.blob.core.windows.net/stories/{Installed2ImageId}";

        [Display(Name = "Is Installed")]
        public bool IsInstalled { get; set; }

        [Display(Name = "Has Calibration")]
        public bool HasCalibration { get; set; }

        //[Display(Name = "Calibration Report")]
        //public Guid ReportId { get; set; }

        //[Display(Name = "Calibration Report")]
        //public string ReportFullPath => ReportId == Guid.Empty
        //    ? $"https://localhost:44320/images/noimage.png"
        //    : $"https://gofpgapistorage.blob.core.windows.net/stories/{ReportId}";

        [Display(Name = "Calibration Done")]
        public bool CalibrationDone { get; set; }
    }
}
