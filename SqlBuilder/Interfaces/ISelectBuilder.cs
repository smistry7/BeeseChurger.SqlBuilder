namespace SqlBuilder.Interfaces
{
    public interface ISelectBuilder : ISqlQueryBuilder
    {
        ISelectBuilder Select(string select);

        IFromBuilder From(string table);
    }
}