namespace DevLib.Infrastructure.Queries
{
    public interface IQuery<out TResult, in TCriterion> where TCriterion : ICriterion
    {
        TResult Ask(TCriterion criterion);
    }
}