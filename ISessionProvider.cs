using NHibernate;

namespace DevLib.Infrastructure.NHibernate
{
    public interface ISessionProvider
    {
        ISession CurrentSession { get; }
    }
}