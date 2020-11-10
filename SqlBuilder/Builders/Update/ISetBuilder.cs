namespace BeeseChurger.SqlBuilder.Builders.Update
{
    public interface ISetBuilder : ISqlQueryBuilder
    {
        /// <summary>
        /// The Set Method
        /// 
        /// Use this to set the fields/values in your update query
        /// </summary>
        /// <example>
        /// <code>
        /// builder.Update("table").Set("x = 6");
        /// </code>
        /// </example>
        /// <param name="sets"></param>
        ISetBuilder Set(string sets);
            /// <summary>
        /// The Set Method
        /// 
        /// Use this to set the fields/values in your update query
        /// </summary>
        /// <example>
        /// <code>
        /// builder.Update("table").Set(x, 6);
        /// </code>
        /// </example>
        ISetBuilder Set(string field, object value);
        /// <summary>
        /// The Where Method
        /// 
        /// Use this method to add a where expression 
        /// </summary>
        /// <example>
        /// This sample shows how to call the Where method.
        /// <code>
        /// builder.Where("Name LIKE '%abc%'");
        /// </code>
        /// </example>
        /// <param name="where">String representation of the where expression</param>
        IWhereBuilder Where(string where);
        /// <summary>
        /// The Where Method
        /// </summary>
        /// <example>
        /// This example shows how to call the where method
        /// <code>
        /// builder.Where("Name", "john");
        /// </code>
        /// </example>
        /// <param name="field">Field to be compared</param>
        /// <param name="value">Value the field should equal</param>
        IWhereBuilder Where(string field, object value);
    }
}
