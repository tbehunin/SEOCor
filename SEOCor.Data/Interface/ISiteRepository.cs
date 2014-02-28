using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEOCor.Domain.Entities;

namespace SEOCor.Data.Interface
{
    public interface ISiteRepository
    {
        IEnumerable<Domain.Entities.Site> GetSites(string userId);
        Domain.Entities.Site GetSite(int siteId);
        int AddSite(string userId, string siteName, string domain, int analyticsSiteId);
        void UpdateSite(int siteId, string siteName, string domain);
    }
}
