﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoFpg.API.Data.Entities
{
    public class GlassType
    {
        public int Id { get; set; }

        [Display(Name = "Part Description")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

        
        [JsonIgnore]
        public ICollection<Quote> Quotes { get; set; }
    }
}
