using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SEOCor.Data.Interface;
using SEOCor.Data.SiteRepository;
using SEOCor.Services.Interfaces;
using SEOCor.Services.SiteService;

namespace SEOCor.Web.App_Start
{
    public class MvcDependencyResolver
    {
        public static void Resolve()
        {
            var builder = new ContainerBuilder();

            // Register dependencies here...
            builder.RegisterType<SiteService>().As<ISiteService>();
            builder.RegisterType<SiteRepository>().As<ISiteRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}