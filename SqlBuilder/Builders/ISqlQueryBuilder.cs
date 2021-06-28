namespace BeeseChurger.SqlBuilder.Builders
{
    /// <summary>
    /// The ISqlQueryBuilder interface.
    /// </summary>
    public interface ISqlQueryBuilder
    {
        /// <summary>
        /// The Build Method
        /// 
        /// Returns the built SQL Query in string format
        /// </summary>
        /// <returns>String representation of the SQL Query</returns>
        string Build();
    }
}