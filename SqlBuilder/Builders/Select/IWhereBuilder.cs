using SqlBuilder.Interfaces;

namespace BeeseChurger.SqlBuilder.Builders.Select
{
    public interface IWhereBuilder : ISqlQueryBuilder
    {
        IWhereBuilder And(string where);

        IWhereBuilder And(string field, object value);

        IWhereBuilder Or(string where);

        IWhereBuilder Or(string field, object value);

        IOrderByBuilder OrderBy(string orderBy);
    }
}