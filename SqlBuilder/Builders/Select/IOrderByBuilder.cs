namespace BeeseChurger.SqlBuilder.Builders.Select
{
    /// <summary>
    /// The IOrderByBuilder interface.
    /// </summary>
    public interface IOrderByBuilder : ISqlQueryBuilder
    {
        /// <summary>
        /// The Paginate Method
        /// </summary>
        /// <example>
        /// <code>
        /// builder.Select("*").From("table").Paginate(4, 20);
        /// </code>
        /// </example>
        /// <param name="pageNumber">integer of the page number to retrieve</param>
        /// <param name="pageSize">integer of the page size</param>
        /// <returns></returns>
        ISqlQueryBuilder Paginate(int pageNumber, int pageSize);
    }
}