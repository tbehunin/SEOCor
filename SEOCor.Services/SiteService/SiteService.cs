using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                AnalyticsSiteId = x.AnalyticsSiteId
            }).ToList();
        }

        public DTO.SiteDTO GetSite(string userId, int siteId)
        {
            return _siteRepository.GetSites(userId)
                .Where(x => x.SiteId.Equals(siteId))
                .Select(x =>
                    new DTO.SiteDTO
                    {
                        Domain = x.Domain,
                        Name = x.Name,
                        SiteId = x.SiteId,
                        AnalyticsSiteId = x.AnalyticsSiteId
                    })
                .SingleOrDefault();
        }

        public int AddSite(string userId, string siteName, string siteUrl)
        {
            var externalId = AddAnalyticsSite(siteName, siteUrl);
            return _siteRepository.AddSite(userId, siteName, siteUrl, externalId);
        }

        public void UpdateSite(string userId, int siteId, string siteName, string siteUrl)
        {
            var site = _siteRepository.GetSites(userId).Where(x => x.SiteId.Equals(siteId)).SingleOrDefault();
            if (site != null)
            {
                UpdateAnalyticsSite(site.AnalyticsSiteId, siteName, siteUrl);
                _siteRepository.UpdateSite(siteId, siteName, siteUrl);
            }
        }

        private int AddAnalyticsSite(string siteName, string siteUrl)
        {
            var analyticsUri = "http://" + ConfigurationManager.AppSettings["privateAnalyticsUri"];
            var analyticsAuthToken = ConfigurationManager.AppSettings["analyticsAuthToken"];
            var urlReq = string.Format("{0}?module=API&method=SitesManager.addSite&siteName={1}&urls={2}&format=JSON&token_auth={3}",
                analyticsUri, siteName, HttpUtility.UrlEncode(siteUrl), analyticsAuthToken);
            var request = (HttpWebRequest)WebRequest.Create(urlReq);
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            var respStream = response.GetResponseStream();

            var serializer = new JsonSerializer();
            var jsonTextReader = new JsonTextReader(new StreamReader(respStream));
            var obj = (JObject)serializer.Deserialize(jsonTextReader);
            return (int)obj["value"];
        }

        private void UpdateAnalyticsSite(int siteId, string siteName, string siteUrl)
        {
            var analyticsUri = "http://" + ConfigurationManager.AppSettings["privateAnalyticsUri"];
            var analyticsAuthToken = ConfigurationManager.AppSettings["analyticsAuthToken"];
            var urlReq = string.Format("{0}?module=API&method=SitesManager.updateSite&idSite={1}&siteName={2}&urls={3}&format=JSON&token_auth={4}",
                analyticsUri, siteId, siteName, HttpUtility.UrlEncode(siteUrl), analyticsAuthToken);
            var request = (HttpWebRequest)WebRequest.Create(urlReq);
            request.Method = "POST";
            request.ContentLength = 0;
            var response = (HttpWebResponse)request.GetResponse();
            var respStream = response.GetResponseStream();

            var serializer = new JsonSerializer();
            var jsonTextReader = new JsonTextReader(new StreamReader(respStream));
            var obj = (JObject)serializer.Deserialize(jsonTextReader);
            var result = (string)obj["result"];
            if (!result.ToUpper().Equals("SUCCESS"))
            {
                var errorMsg = (string)obj["message"];
                throw new Exception(string.Format("Failed to update analytics site: {0}", errorMsg));
            }
        }
    }
}
