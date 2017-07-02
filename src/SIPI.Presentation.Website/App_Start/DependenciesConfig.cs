using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using SIPI.Presentation.Website.App_Start.Modules;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace SIPI.Presentation.Website
{
    public class DependenciesConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new CoreModule());

            var assembly = Assembly.Load("SIPI.Presentation.Website");

            RegisterMVC(builder, assembly);
            RegisterWebApi(builder, assembly);

            var container = builder.Build();

            SetMVCResolver(container);
            SetWebApiResolver(container);
        }

        private static void SetWebApiResolver(IContainer container)
        {
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void SetMVCResolver(IContainer container)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterWebApi(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterApiControllers(assembly);
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
        }

        private static void RegisterMVC(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterModelBinderProvider();
            builder.RegisterFilterProvider();
            builder.RegisterControllers(assembly);
        }
    }
}