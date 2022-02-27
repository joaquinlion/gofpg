using GoFpg.API.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoFpg.API.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de vehículo")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un tipo de verhículo.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int VehicleTypeId { get; set; }

        public IEnumerable<SelectListItem> VehicleTypes { get; set; }

        [Display(Name = "Marca")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una marca.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int BrandId { get; set; }

        public IEnumerable<SelectListItem> Brands { get; set; }

        [Display(Name = "Year")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1900, 2100, ErrorMessage = "Valor de módelo no válido.")]
        public int Year { get; set; }

        [Display(Name = "VIN Number")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string VinNumber { get; set; }

        [Display(Name = "Tag")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(7, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string Tag { get; set; }

        [Display(Name = "Make")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Make { get; set; }

        [Display(Name = "Model")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Model { get; set; }

        [Display(Name = "Color")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
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
        [MaxLength(90, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string VehicleType { get; set; }

        [Display(Name = "LDWS")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LaneDeparture { get; set; }

        [Display(Name = "Lane Keep Assist")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LaneKeep { get; set; }

        [Display(Name = "ErrorCode")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string ErrorCode { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "VIN Picture")]
        public IFormFile VinImageFile { get; set; }

        [Display(Name = "Foto")]
        public IFormFile ImageFile { get; set; }

        public ICollection<VehiclePhoto> VehiclePhotos { get; set; }
    }
}
