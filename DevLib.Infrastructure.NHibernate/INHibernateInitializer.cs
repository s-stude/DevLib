using NHibernate.Cfg;

namespace DevLib.Infrastructure.NHibernate
{
    public interface INHibernateInitializer
    {
        Configuration GetConfiguration();
    }
}