using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace GoFpg.API.Data.Entities
{
    public class Quote
    { 
        public int QuoteId { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debes introducir un email válido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName => $"{FirstName} {LastName}";

        [Display(Name = "Customer Address")]
        public string CustoAddress => $"{Address} Apt. {Address2} {City} {State} {Zip}";

        [Display(Name = "Street Adress")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string Address { get; set; }

        [Display(Name = "Apartment, Unit or Suite #")]
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

        [Display(Name = "Phone Number")]
        [MaxLength(14, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "VIN Number")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string VinNumber { get; set; }

        [Display(Name = "Vehicle")]
        public string CustomerVehicle => $"{Year} {Make} {Model} {Doors} Doors {BodyClass}";

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

        [Display(Name = "What Insurance Company has an actual Policy with this car?")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string InsuranceCompany { get; set; }

        [Display(Name = "Date of Loss")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime DateOfLoss { get; set; }

        [Display(Name = "Glass Requested")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public GlassType GlassType { get; set; }

        [Display(Name = "Repair Order")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public RepairOrder RepairOrder { get; set; }


    }
}

