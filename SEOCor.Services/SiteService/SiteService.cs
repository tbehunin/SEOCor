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

        public IEnumerable<DTO.SiteDTO> GetSites(string userId)
        {
            return _siteRepository.GetSites(userId).Select(x => new DTO.SiteDTO
            {
                Domain = x.Domain,
                Name = x.Name,
                SiteId = x.SiteId,
                TrackingCode = x.TrackingCode
            }).ToList();
        }

        public DTO.SiteDTO GetSite(int siteId)
        {
            var site = _siteRepository.GetSite(siteId);
            return new DTO.SiteDTO
            {
                Domain = site.Domain,
                Name = site.Name,
                SiteId = site.SiteId,
                TrackingCode = site.TrackingCode
            };
        }

        public int AddSite(string userId, string name, string domain)
        {
            return _siteRepository.AddSite(userId, name, domain);
        }

        public void UpdateSite(int siteId, string name, string domain)
        {
            _siteRepository.UpdateSite(siteId, name, domain);
        }
    }
}
