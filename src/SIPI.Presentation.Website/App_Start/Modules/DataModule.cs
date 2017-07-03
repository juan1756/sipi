using Autofac;
using System.Linq;
using System.Reflection;

namespace SIPI.Presentation.Website.App_Start.Modules
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assembly = Assembly.Load("SIPI.Data.EF");

            RegisterDataContext(builder, assembly);
            RegisterMappers(builder, assembly);
        }

        private static void RegisterDataContext(ContainerBuilder builder, Assembly assembly)
        {
            builder
                .RegisterType(assembly.GetTypes().Single(x => x.Name == "DataContext"))
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        private void RegisterMappers(ContainerBuilder builder, Assembly assembly)
        {
            builder
                .RegisterTypes(assembly.GetTypes().Where(x => x.Name.EndsWith("Mapper")).ToArray())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}