using GoFpg.API.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GoFpg.API.Models
{
    public class DetailedQuoteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "please fill with a valid email address")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "{0} field cannot contain more than {1} characters.")]
        [Required(ErrorMessage = "Please fill with the {0}.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "{0} field cannot contain more than {1} characters.")]
        [Required(ErrorMessage = "Please fill with the {0}.")]
        public string LastName { get; set; }

        [Display(Name = "Street Adress")]
        [MaxLength(100, ErrorMessage = "{0} field cannot contain more than {1} characters.")]
        public string Address { get; set; }

        [Display(Name = "Apt., Unit or Suite #")]
        [MaxLength(7, ErrorMessage = "{0} field cannot contain more than {1} characters.")]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        [MaxLength(30, ErrorMessage = "{0} field cannot contain more than {1} characters.")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        [MaxLength(10, ErrorMessage = "{0} field cannot contain more than {1} characters.")]
        public string Zip { get; set; }

        [Display(Name = "State")]
        [MaxLength(16, ErrorMessage = "{0} field cannot contain more than {1} characters.")]
        public string State { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(14, ErrorMessage = "{0} field cannot contain more than {1} characters.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "VIN Number")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string VinNumber { get; set; }

        [Display(Name = "Year")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //[Range(1900, 2100, ErrorMessage = "Valor de módelo no válido.")]
        public int Year { get; set; }

        [Display(Name = "Make")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Make { get; set; }

        [Display(Name = "Model")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Model { get; set; }

        [Display(Name = "Doors")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Doors { get; set; }

        [Display(Name = "Body Class")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string BodyClass { get; set; }

        [Display(Name = "Vehicle Type")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string VehicleType { get; set; }

        [Display(Name = "LDWS")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LaneDeparture { get; set; }

        [Display(Name = "Lane Keep Assist")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LaneKeep { get; set; }

        [Display(Name = "Which Glass needs to be Repaired/Replaced?")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select the Glass you need to replace/repair")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int GlassTypeId { get; set; }

        public IEnumerable<SelectListItem> GlassTypes { get; set; }

        [Display(Name = "What Insurance Company has an actual Policy in this car?")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string InsuranceCompany { get; set; }

        [Display(Name = "When did the damage occur?")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime DateOfLoss { get; set; }

        [Display(Name = "Billed to:?")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string BilledTo { get; set; }



        //[Display(Name = "Foto")]
        //public Guid ImageId { get; set; }

        //[Display(Name = "Tipo de usuario")]
        //public UserType UserType { get; set; }

        //[Display(Name = "Foto")]
        //public IFormFile ImageFile { get; set; }

        //[Display(Name = "Tipo de documento")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un tipo de documento.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //public int DocumentTypeId { get; set; }

        //public IEnumerable<SelectListItem> DocumentTypes { get; set; }

        //[Display(Name = "Foto")]
        //public string ImageFullPath => ImageId == Guid.Empty
        //    ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
        //    : $"https://fpglass.blob.core.windows.net/users/{ImageId}";
    }
}
