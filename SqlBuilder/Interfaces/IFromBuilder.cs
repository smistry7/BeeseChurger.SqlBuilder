namespace SqlBuilder.Interfaces
{
    public interface IFromBuilder : ISqlQueryBuilder
    {
        IWhereBuilder Where(string where);
        IJoinBuilder InnerJoin(string joiningTable);
        IJoinBuilder RightJoin(string joiningTable);
        IJoinBuilder LeftJoin(string joiningTable);
        IOrderByBuilder OrderBy(string field);
    }
}
