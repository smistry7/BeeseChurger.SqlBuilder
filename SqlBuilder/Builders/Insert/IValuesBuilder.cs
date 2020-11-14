namespace BeeseChurger.SqlBuilder.Builders.Insert
{
    public interface IValuesBuilder : ISqlQueryBuilder
    {
        ISqlQueryBuilder Values(object[] values);
    }
}