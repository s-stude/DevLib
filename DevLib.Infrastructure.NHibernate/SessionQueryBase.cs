using DevLib.Infrastructure.Queries;
using NHibernate;

namespace DevLib.Infrastructure.NHibernate
{
    public abstract class SessionQueryBase<TResult, TCriterion> : IQuery<TResult, TCriterion>
        where TCriterion : ICriterion
    {
        private readonly ISessionProvider _sessionProvider;

        protected SessionQueryBase(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        protected virtual ISession Session
        {
            get { return _sessionProvider.CurrentSession; }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}