using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SEOCor.Services.DTO;
using SEOCor.Services.Interfaces;
using SEOCor.Web.Models;

namespace SEOCor.Web.Controllers
{
    [Authorize]
    public class SiteController : Controller
    {
        private ISiteService _siteService;

        //public SiteController() { }
        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }
        //
        // GET: /Site/
        public ActionResult Index()
        {
            var sites = _siteService.GetSites(User.Identity.GetUserId());
            return View(sites);
        }

        //
        // GET: /Site/Details/5
        public ActionResult TrackingScript(int id)
        {
            string format = @"<!-- SEOCor -->
                <script type=""text/javascript"">
                  var _paq = _paq || [];
                  _paq.push(['trackPageView']);
                  _paq.push(['enableLinkTracking']);
                  (function() {
                    var u=((""https:"" == document.location.protocol) ? ""https"" : ""http"") + ""://{{0}}/"";
                    _paq.push(['setTrackerUrl', u+'piwik.php']);
                    _paq.push(['setSiteId', 1]);
                    var d=document, g=d.createElement('script'), s=d.getElementsByTagName('script')[0]; g.type='text/javascript';
                    g.defer=true; g.async=true; g.src=u+'piwik.js'; s.parentNode.insertBefore(g,s);
                  })();

                </script>
                <noscript><p><img src=""http://{{0}}/piwik.php?idsite=1"" style=""border:0;"" alt="""" /></p></noscript>
                <!-- End SEOCor Code -->";
            return View(new TrackingScriptModel
            {
                Site = _siteService.GetSite(User.Identity.GetUserId(), id),
                TrackingScript = HttpUtility.HtmlAttributeEncode(format)//string.Format(format, ConfigurationManager.AppSettings["analyticsUri"]))
            });
        }

        //
        // GET: /Site/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Site/Create
        [HttpPost]
        public ActionResult Create(SiteDTO site)
        {
            int id = _siteService.AddSite(User.Identity.GetUserId(), site.Name, site.Domain);
            return RedirectToAction("Index");
        }

        //
        // GET: /Site/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_siteService.GetSite(User.Identity.GetUserId(), id));
        }

        //
        // POST: /Site/Edit/5
        [HttpPost]
        public ActionResult Edit(SiteDTO site)
        {
            _siteService.UpdateSite(site.SiteId, site.Name, site.Domain);
            return RedirectToAction("Index");
        }

        //
        // GET: /Site/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        //
        // POST: /Site/Delete/5
        /*[HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
