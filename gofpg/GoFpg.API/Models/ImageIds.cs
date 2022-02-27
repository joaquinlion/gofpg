using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoFpg.API.Models
{
    public class ImageIds
    {
        public Guid PolicyImageId { get; set; } = Guid.Empty;
        public Guid InvoiceImageId { get; set; } = Guid.Empty;
        public Guid VinImageId { get; set; } = Guid.Empty;
    }
}
