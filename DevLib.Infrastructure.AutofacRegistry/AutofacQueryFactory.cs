using Autofac;
using DevLib.Infrastructure.Queries;
using JetBrains.Annotations;

namespace DevLib.Infrastructure.AutofacRegistry
{
    [UsedImplicitly]
    public class AutofacQueryFactory : IQueryFactory
    {
        private readonly ILifetimeScope _scope;

        public AutofacQueryFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IQuery<TResult, TCriterion> Create<TResult, TCriterion>() where TCriterion : ICriterion
        {
            var query = _scope.Resolve<IQuery<TResult, TCriterion>>();

            return query;
        }
    }
}