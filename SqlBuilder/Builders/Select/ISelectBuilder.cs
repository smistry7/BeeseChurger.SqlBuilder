namespace BeeseChurger.SqlBuilder.Builders.Select
{
    /// <summary>
    /// The ISelectBuilder interface
    /// </summary>
    public interface ISelectBuilder : ISqlQueryBuilder
    {
        /// <summary>
        /// The Select method
        /// 
        /// Use this to initiate a SQL Select query
        /// </summary>
        /// <param name="select">String representation of the fields to be selected</param>
        /// <returns>Current instance of ISelectBuilder</returns>
        ISelectBuilder Select(string select);

        /// <summary>
        /// The From Method
        /// 
        /// Use this after a Select method to select a table to query
        /// </summary>
        /// <param name="table">String representation of the SQL table to be queried</param>
        /// <returns>Current instance of IFromBuilder</returns>
        IFromBuilder From(string table);
    }
}