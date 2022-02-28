using GoFpg.API.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace GoFpg.API.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Display(Name = "Make")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Make { get; set; }

        [Display(Name = "VIN Number")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string VinNumber { get; set; }

        [Display(Name = "Year")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1900, 2100, ErrorMessage = "Valor de módelo no válido.")]
        public int Year { get; set; }

        [Display(Name = "License Tag")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(7, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string Tag { get; set; }

        [Display(Name = "Model")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Model { get; set; }

        [Display(Name = "Color")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Color { get; set; }

        [Display(Name = "Doors")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Doors { get; set; }

        [Display(Name = "Body Class")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string BodyClass { get; set; }

        [Display(Name = "Vehicle Type")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string VehicleType { get; set; }

        [Display(Name = "LDWS")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LaneDeparture { get; set; }

        [Display(Name = "Lane Keep Assist")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LaneKeep { get; set; }

        [Display(Name = "Propietario")]
        [JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public User User { get; set; }

        public ICollection<InsuranceClaim> InsuranceClaims { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "Year/Make/Model/Color")]
        public string VehicleDescription => $"{Year} {Make} {Model} {Color}";

        [Display(Name = "Vehicle Type")]
        public string DoorsNBody => $"{Doors} {"Doors"} {BodyClass}";

        public ICollection<VehiclePhoto> VehiclePhotos { get; set; }

        [Display(Name = "# Fotos")]
        public int VehiclePhotosCount => VehiclePhotos == null ? 0 : VehiclePhotos.Count;

        [Display(Name = "Foto")]
        public string ImageFullPath => VehiclePhotos == null || VehiclePhotos.Count == 0
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : VehiclePhotos.FirstOrDefault().ImageFullPath;

        public ICollection<History> Histories { get; set; }

        [Display(Name = "# Historias")]
        public int HistoriesCount => Histories == null ? 0 : Histories.Count;
    }
}
