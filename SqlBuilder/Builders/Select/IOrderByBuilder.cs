namespace BeeseChurger.SqlBuilder.Builders.Select
{
    /// <summary>
    /// The IOrderByBuilder interface.
    /// </summary>
    public interface IOrderByBuilder
    {
        /// <summary>
        /// The Ascending Method
        /// 
        /// Use this after an OrderBy Method to add an ASC to your SQL query
        /// </summary>
        IFromBuilder Ascending();
        /// <summary>
        /// The Descending Method
        /// 
        /// Use this Method after an OrderBy to add a DESC to your SQL query
        /// </summary>
        /// <returns></returns>
        IFromBuilder Descending();
    }
}