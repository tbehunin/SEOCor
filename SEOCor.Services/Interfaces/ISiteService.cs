using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEOCor.Services.DTO;

namespace SEOCor.Services.Interfaces
{
    public interface ISiteService
    {
        IEnumerable<SiteDTO> GetSites(string userId);
        SiteDTO GetSite(string userId, int siteId);
        int AddSite(string userId, string siteName, string domain);
        void UpdateSite(string userId, int siteId, string siteName, string domain);
    }
}
