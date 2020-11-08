namespace BeeseChurger.SqlBuilder.Builders.Select
{
    public interface IFromBuilder : ISqlQueryBuilder
    {
        IWhereBuilder Where(string where);

        IWhereBuilder Where(string field, object value);

        IJoinBuilder InnerJoin(string joiningTable);

        IJoinBuilder RightJoin(string joiningTable);

        IJoinBuilder LeftJoin(string joiningTable);

        IOrderByBuilder OrderBy(string field);

        ISqlQueryBuilder Paginate(int pageNumber, int pageSize);
    }
}