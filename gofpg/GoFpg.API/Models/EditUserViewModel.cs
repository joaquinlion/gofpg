using GoFpg.API.Data.Entities;
using GoFpg.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoFpg.API.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "{0} field can not be more than {1} characters.")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "{0} field can not be more than {1} characters.")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string LastName { get; set; }

        [Display(Name = "Id type")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select Id. type.")]
        [Required(ErrorMessage = "{0} field is required.")]
        public int DocumentTypeId { get; set; }

        public IEnumerable<SelectListItem> DocumentTypes { get; set; }

        [Display(Name = "Id number")]
        [MaxLength(20, ErrorMessage = "{0} field can not be more than {1} characters.")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string Document { get; set; }

        [Display(Name = "Address")]
        [MaxLength(100, ErrorMessage = "{0} field can not be more than {1} characters.")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string Address { get; set; }

        [Display(Name = "Telephone")]
        [MaxLength(10, ErrorMessage = "{0} field can not be more than {1} characters.")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "User Image")]
        public Guid ImageId { get; set; }

        [Display(Name = "User Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"{Constants.BaseUrlLocalImages}/images/noimage.png"
            : $"{Constants.BaseUrlBlobImages}/users/{ImageId}";

        [Display(Name = "User Image Image")]
        public IFormFile ImageFile { get; set; }

    }
}
