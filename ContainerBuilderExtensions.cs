using Autofac;
using DevLib.Domain;
using NHibernate;

namespace DevLib.Infrastructure.NHibernate.AutofacRegistry
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder RegisterInfrastructureNHibernateComponents(this ContainerBuilder builder)
        {
            builder.RegisterType<PerRequestSessionProvider>().As<ISessionProvider>();

            builder.RegisterType<NHibernateUnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<NHibernateUnitOfWorkFactory>().As<IUnitOfWorkFactory>();

            builder.RegisterGeneric(typeof(NHibernateRepositoryBase<>)).As(typeof(IRepository<>));

            builder.Register(ctx =>
            {
                var nhInitializer = ctx.Resolve<INHibernateInitializer>();
                ISessionFactory sessionFactory = nhInitializer.GetConfiguration().BuildSessionFactory();
                return sessionFactory;
            })
                   .As<ISessionFactory>()
                   .SingleInstance();

            return builder;
        }
    }
}