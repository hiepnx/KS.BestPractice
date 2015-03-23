using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using KS.BestPractice.Cache.DI;

namespace KS.BestPractice
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var builder = new ContainerBuilder();
            var container = builder.Build();

            builder = new ContainerBuilder();
            IDependencyRegistrar dr = new DependencyRegistrar();
            dr.Register(builder);
            builder.Update(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            
        }
    }
}