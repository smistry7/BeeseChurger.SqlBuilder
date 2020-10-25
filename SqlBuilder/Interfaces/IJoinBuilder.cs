namespace SqlBuilder.Interfaces
{
    public interface IJoinBuilder : ISqlQueryBuilder
    {
        IFromBuilder On(string on);
    }
}