using Autofac;
using DevLib.Infrastructure.Queries.Impl;

namespace DevLib.Infrastructure.AutofacRegistry
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder RegisterInfrastructureCommandQueryComponents(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof (QueryFor<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<AutofacCommandHandlerFactory>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<AutofacQueryFactory>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<AutofacQueryBuilder>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            return builder;
        }
    }
}