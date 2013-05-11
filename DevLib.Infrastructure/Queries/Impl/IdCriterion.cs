namespace DevLib.Infrastructure.Queries.Impl
{
    public class IdCriterion : ICriterion
    {
        public int Id { get; set; }

        public IdCriterion(int id)
        {
            Id = id;
        }
    }
}