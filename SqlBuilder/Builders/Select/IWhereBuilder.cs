using System;

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
        IWhereBuilder And(FormattableString where);
        /// <summary>
        /// The And method
        /// 
        /// Use this method after a where to add an AND expression
        /// </summary>
        /// <param name="field">Field/column to compare</param>
        /// <param name="value">Value to set it equal to</param>
        IWhereBuilder And(string field, object value);
        /// <summary>
        /// The Or Method
        /// 
        /// Use this method after a where to add an OR expression
        /// </summary>
        /// <param name="where">string representation of the or expression</param>
        IWhereBuilder Or(FormattableString where);
        /// <summary>
        /// The Or method
        /// 
        /// Use this method after a where to add an OR expression
        /// </summary>
        /// <param name="field">Field/column to compare</param>
        /// <param name="value">Value to set it equal to</param>
        IWhereBuilder Or(string field, object value);
        /// <summary>
        /// The OrderBy Method
        /// 
        /// Use this method to add an Order By expression in a SQL query
        /// </summary>
        /// <param name="orderBy">field/column to order by</param>
        /// <returns></returns>
        IOrderByBuilder OrderBy(string orderBy);
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