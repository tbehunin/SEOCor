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
        IEnumerable<Site> GetSites(string userId);
        Site GetSite(int siteId);
        int AddSite(string userId, string name, string domain);
        void UpdateSite(int siteId, string name, string domain);
    }
}
