using BeeseChurger.SqlBuilder.Builders.Update;
using BeeseChurger.SqlBuilder.Misc;
using System;
using System.Text;

namespace BeeseChurger.SqlBuilder
{
    /// <summary>
    /// The UpdateBuilder fluent builder class 
    /// </summary>
    public sealed class UpdateBuilder : ISetBuilder, IWhereBuilder
    {
        private StringBuilder _sql;
        private UpdateBuilder(string table)
        {
            _sql = new StringBuilder();
            _sql.Append($"UPDATE {table} SET");
        }

        /// <inheritdoc/>
        public static ISetBuilder Update(string table)
        {
            var builder = new UpdateBuilder(table);
            return builder;
        }

        /// <inheritdoc/>
        public ISetBuilder Set(FormattableString sets)
        {
            
            _sql.Append($"{sets.HandleSqlInjection()} ");
            return this;
        }

        private string _setSeparator = " ";
        /// <inheritdoc/>
        public ISetBuilder Set(string field, object value)
        {
            if (value != null)
            {
                _sql.Append($"{_setSeparator}{field} = {value.ToSqlParameter()}");
            }
            else 
            {
                _sql.Append($"{_setSeparator}{field} = NULL");
            }
            _setSeparator = ", ";
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder Where(FormattableString where)
        {
            _sql.Append($" WHERE {where.HandleSqlInjection()} ");
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder Where(string field, object value)
        {
            _sql.Append($" WHERE {field} = {value.ToSqlParameter()} ");
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder And(FormattableString where)
        {
            _sql.Append($"AND {where.HandleSqlInjection()} ");
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder And(string field, object value)
        {
            _sql.Append($"AND {field} = {value.ToSqlParameter()} ");
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder Or(FormattableString where)
        {
            _sql.Append($"AND {where.HandleSqlInjection()} ");
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder Or(string field, object value)
        {
            _sql.Append($"AND {field} = {value.ToSqlParameter()} ");
            return this;
        }

        /// <inheritdoc/>
        public string Build()
        {
            _sql.Append(";");
            return _sql.ToString();
        }
   
    }
}
