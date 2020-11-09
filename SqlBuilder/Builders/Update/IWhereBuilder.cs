namespace BeeseChurger.SqlBuilder.Builders.Update
{
    public interface IWhereBuilder : ISqlQueryBuilder
    {
        IWhereBuilder And(string where);

        IWhereBuilder And(string field, object value);

        IWhereBuilder Or(string where);

        IWhereBuilder Or(string field, object value);
    }
}
