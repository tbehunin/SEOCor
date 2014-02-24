using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEOCor.Data.Interface;
using SEOCor.Services.Interfaces;

namespace SEOCor.Services.SiteService
{
    public class SiteService : ISiteService
    {
        private ISiteRepository _siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public IList<DTO.SiteDTO> GetSites(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
