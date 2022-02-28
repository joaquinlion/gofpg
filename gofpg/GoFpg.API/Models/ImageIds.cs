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
        public Guid TagImageId { get; set; } = Guid.Empty;
        public Guid VinImageId { get; set; } = Guid.Empty;
        public Guid DamageImageId { get; set; } = Guid.Empty;
        public Guid FullDamageImageId { get; set; } = Guid.Empty;
        public Guid InteriorImageId { get; set; } = Guid.Empty;
        public Guid InstalledImageId { get; set; } = Guid.Empty;
        public Guid Installed2ImageId { get; set; } = Guid.Empty;
        public Guid ReportId { get; set; } = Guid.Empty;
        public Guid SignedROImageId { get; set; } = Guid.Empty;
    }
}
