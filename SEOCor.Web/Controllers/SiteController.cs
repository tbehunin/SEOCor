using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SEOCor.Services.DTO;
using SEOCor.Services.Interfaces;

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
        public ActionResult Details(int id)
        {
            return View(_siteService.GetSite(id));
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
            try
            {
                int id = _siteService.AddSite(User.Identity.GetUserId(), site.Name, site.Domain);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Site/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_siteService.GetSite(id));
        }

        //
        // POST: /Site/Edit/5
        [HttpPost]
        public ActionResult Edit(SiteDTO site)
        {
            try
            {
                _siteService.UpdateSite(site.SiteId, site.Name, site.Domain);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
