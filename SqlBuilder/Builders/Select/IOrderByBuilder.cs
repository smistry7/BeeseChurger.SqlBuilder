namespace SqlBuilder.Interfaces
{
    public interface IOrderByBuilder : ISqlQueryBuilder
    {
        IFromBuilder Ascending();

        IFromBuilder Descending();
    }
}