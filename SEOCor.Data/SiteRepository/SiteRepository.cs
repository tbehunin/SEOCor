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
            return new List<Domain.Entities.Site>
            {
                new Site
                {
                    Domain = "domain1",
                    Name = "name1",
                    SiteId = 1,
                    TrackingCode = "trackingcode1"
                },
                new Site
                {
                    Domain = "domain2",
                    Name = "name2",
                    SiteId = 2,
                    TrackingCode = "trackingcode2"
                }
            };
            /*var sproc = "wotc_AddMtGOLoginEvent";

            // Build parameter object
            dynamic parameters = new DynamicParameters();
            parameters.AddDynamicParams(new
            {
                UserId = userId
            });
            parameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            // Execute sproc and get result
            var sites = Query<Site>(sproc, parameters);
            var returnValue = parameters.Get<int>("@ReturnValue");

            if (!returnValue.Equals(0))
            {
                throw new Exception(string.Format("Stored Procedure '{0}' did not return zero (which indicates success).", sproc));
            }

            return sites;*/
        }


        public Site GetSite(int siteId)
        {
            return new Site
            {
                Domain = "domain1",
                Name = "name1",
                SiteId = 1,
                TrackingCode = "trackingcode1"
            };
        }

        public int AddSite(string userId, string name, string domain)
        {
            return 123;
        }

        public void UpdateSite(int siteId, string name, string domain)
        {
            // todo
        }
    }
}
