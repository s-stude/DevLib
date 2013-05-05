namespace DevLib.Infrastructure.Queries
{
    public interface IQueryBuilder
    {
        IQueryFor<T> For<T>();
    }
}