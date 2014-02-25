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
        SiteDTO GetSite(int siteId);
        int AddSite(string userId, string name, string domain);
        void UpdateSite(int siteId, string name, string domain);
    }
}
