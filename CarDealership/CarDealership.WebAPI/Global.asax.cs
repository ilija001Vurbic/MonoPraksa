using CarDealership.Repository;
using AutoMapper;
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
using CarDealership.Model;
using CarDealership.Model.Common;
using Microsoft.Extensions.DependencyInjection;

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
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.CreateMap<CarModelRest,CarModel>();
                cfg.CreateMap<CarModel, CarModelRest>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var cfg = context.Resolve<MapperConfiguration>();
                return cfg.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
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
