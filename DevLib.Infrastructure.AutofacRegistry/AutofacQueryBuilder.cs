using Autofac;
using DevLib.Infrastructure.Queries;
using JetBrains.Annotations;

namespace DevLib.Infrastructure.AutofacRegistry
{
    [UsedImplicitly]
    public class AutofacQueryBuilder : IQueryBuilder
    {
        readonly ILifetimeScope _scope;

        public AutofacQueryBuilder(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IQueryFor<T> For<T>()
        {
            var queryFor = _scope.Resolve<IQueryFor<T>>();
            
            return queryFor;
        }
    }
}