using CarDealership.Repository;
using CarDealership.Repository.Common;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CarDealership.Service;
using CarDealership.Service.Common;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace CarDealership.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterType<CarRepository>().As<ICarRepository>();
            builder.RegisterType<CarModelRepository>().As<ICarModelRepositoryCommon>();
            builder.RegisterType<CarService>().As<ICarService>();
            builder.RegisterType<CarModelService>().As<ICarModelService>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiModelBinderProvider();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
