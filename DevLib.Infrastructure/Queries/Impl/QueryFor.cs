namespace DevLib.Infrastructure.Queries.Impl
{
    public class QueryFor<T> : IQueryFor<T>
    {
        private readonly IQueryFactory _queryFactory;

        public QueryFor(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public T With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion
        {
            return _queryFactory.Create<T, TCriterion>().Ask(criterion);
        }

        public T WithEmptyCriterion()
        {
            return _queryFactory.Create<T, NullCriterion>().Ask(new NullCriterion());
        }

        public T WithIdCriterion(int id)
        {
            return _queryFactory.Create<T, IdCriterion>().Ask(new IdCriterion(id));
        }
    }
}