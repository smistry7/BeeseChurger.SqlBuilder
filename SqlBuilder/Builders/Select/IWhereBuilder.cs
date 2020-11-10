namespace BeeseChurger.SqlBuilder.Builders.Select
{
    public interface IWhereBuilder : ISqlQueryBuilder
    {
        /// <summary>
        /// The And Method
        /// 
        /// Use this method after a where to add an AND expression
        /// </summary>
        /// <param name="where">string representation of the and expression</param>
        IWhereBuilder And(string where);
        
        IWhereBuilder And(string field, object value);

        IWhereBuilder Or(string where);

        IWhereBuilder Or(string field, object value);

        IOrderByBuilder OrderBy(string orderBy);
        ISqlQueryBuilder Paginate(int pageNumber, int pageSize);
    }
}