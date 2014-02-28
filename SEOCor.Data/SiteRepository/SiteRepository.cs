using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SEOCor.Data.Interface;
using SEOCor.Domain.Entities;

namespace SEOCor.Data.SiteRepository
{
    public class SiteRepository : RepositoryBase, ISiteRepository
    {
        public SiteRepository(string connectionString) : base(connectionString) { }

        public IEnumerable<Domain.Entities.Site> GetSites(string userId)
        {
            return DataContext.UserSites
                .Where(x => x.UserId.Equals(userId))
                .Select(x => new Domain.Entities.Site
                {
                    SiteId = x.Site.SiteId,
                    Name = x.Site.Name,
                    Domain = x.Site.Domain,
                    AnalyticsSiteId = x.Site.AnalyticsSiteId
                }).ToList();
        }


        public Domain.Entities.Site GetSite(int siteId)
        {
            return DataContext.Sites.Where(x => x.SiteId.Equals(siteId)).Select(x => new Domain.Entities.Site
                {
                    SiteId = x.SiteId,
                    Name = x.Name,
                    Domain = x.Domain,
                    AnalyticsSiteId = x.AnalyticsSiteId
                }).SingleOrDefault();
        }

        public int AddSite(string userId, string siteName, string domain, int analyticsSiteId)
        {
            var userSite = new UserSite
            {
                UserId = userId,
                Site = new Site
                {
                    Name = siteName,
                    Domain = domain,
                    AnalyticsSiteId = analyticsSiteId
                }
            };
            DataContext.UserSites.InsertOnSubmit(userSite);
            DataContext.SubmitChanges();
            return userSite.Site.SiteId;
        }

        public void UpdateSite(int siteId, string siteName, string domain)
        {
            var site = DataContext.Sites.Where(x => x.SiteId.Equals(siteId)).SingleOrDefault();
            site.Name = siteName;
            site.Domain = domain;
            DataContext.SubmitChanges();
        }
    }
}
