namespace BeeseChurger.SqlBuilder.Builders.Select
{
    /// <summary>
    /// The IJoinBuilder interface.
    /// </summary>
    public interface IJoinBuilder
    {
        /// <summary>
        /// The On Method
        /// 
        /// Use this method after a Join method to set your on clause
        /// </summary>
        /// <example>
        /// <code>
        /// builder.Select("*").From("table").LeftJoin("otherTable").On("a = b");
        /// </code>
        /// </example>
        /// <param name="on">String representation of the on clause</param>
        IFromBuilder On(string on);
    }
}