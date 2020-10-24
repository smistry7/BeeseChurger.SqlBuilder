namespace SqlBuilder.Interfaces
{
    public interface IWhereBuilder : ISqlQueryBuilder
    {
        IWhereBuilder And(string where);
        IWhereBuilder Or(string where);
        IOrderByBuilder OrderBy(string orderBy);
    }
}
