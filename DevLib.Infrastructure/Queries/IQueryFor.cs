namespace DevLib.Infrastructure.Queries
{
    public interface IQueryFor<out T>
    {
        T With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion;
        T WithEmptyCriterion();
        T WithIdCriterion(int id);
    }
}