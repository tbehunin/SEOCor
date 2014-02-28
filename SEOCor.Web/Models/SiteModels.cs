using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEOCor.Services.DTO;

namespace SEOCor.Web.Models
{
    public class TrackingScriptModel
    {
        public SiteDTO Site { get; set; }
        public string TrackingScript { get; set; }
    }
}