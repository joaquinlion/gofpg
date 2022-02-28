using GoFpg.API.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoFpg.API.Data.Entities
{
    public class VehiclePhoto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/vehicles/{ImageId}";
    }
}
