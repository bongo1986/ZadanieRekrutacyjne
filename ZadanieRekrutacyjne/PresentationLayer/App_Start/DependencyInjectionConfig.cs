using Autofac;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BusinessLogic.Services;


namespace PresentationLayer
{
    public class DependencyInjectionConfig
    {
        public static IContainer GetContainer()
        {

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<DevContractsContext>().As<IDevContractsContext>().InstancePerLifetimeScope();
            builder.RegisterType<DevContractsRepository>().As<IDevContractsRepository>().InstancePerRequest();
            builder.RegisterType<DevContractsService>().As<IDevContractsService>().InstancePerRequest();
            

            return builder.Build();

          
        }
    }
}