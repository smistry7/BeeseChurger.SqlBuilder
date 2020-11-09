namespace BeeseChurger.SqlBuilder.Builders.Update
{
    public interface ISetBuilder : ISqlQueryBuilder
    {
        ISetBuilder Set(string sets);
        
        ISetBuilder Set(string field, object value);
        IWhereBuilder Where(string where);
        IWhereBuilder Where(string field, object value);
    }
}
