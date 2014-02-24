using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEOCor.Data.Interface;

namespace SEOCor.Data.SiteRepository
{
    public class SiteRepository : ISiteRepository
    {
        public SiteRepository()
        {

        }

        public IList<Domain.Entities.Site> GetSitesByUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
