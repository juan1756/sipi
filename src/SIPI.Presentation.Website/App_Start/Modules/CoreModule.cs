using Autofac;
using System.Linq;
using System.Reflection;

namespace SIPI.Presentation.Website.App_Start.Modules
{
    public class CoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assembly = Assembly.Load("SIPI.Core");

            builder
                .RegisterTypes(assembly.GetTypes()
                    .Where(x => x.Name.EndsWith("Controlador"))
                    .ToArray())
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}