namespace DevLib.Infrastructure.Queries
{
    public interface IQueryFactory
    {
        IQuery<TResult, TCriterion> Create<TResult, TCriterion>()  where TCriterion : ICriterion;
    }
}