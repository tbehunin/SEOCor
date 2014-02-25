using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOCor.Domain.Entities
{
    public class Site
    {
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string TrackingCode { get; set; }
    }
}
