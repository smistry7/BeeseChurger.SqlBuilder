using BeeseChurger.SqlBuilder.Builders;
using BeeseChurger.SqlBuilder.Builders.Insert;
using BeeseChurger.SqlBuilder.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeeseChurger.SqlBuilder
{
    /// <summary>
    /// The InsertBuilder fluent builder class.
    /// </summary>
    public sealed class InsertBuilder : IValuesBuilder
    {
        private StringBuilder _sql;
        private List<object> _values = new List<object>();
        private InsertBuilder(string table, IEnumerable<string> columns)
        {
            _sql = new StringBuilder();
            _sql.Append($"INSERT INTO {table} ");
            if (columns != null)
            {
                AppendColumns(columns);
            }
            _sql.Append("VALUES (");
        }


        /// <summary>
        /// The Insert Into Method
        ///
        /// Use this to instantiate your insert into query with a table and collection of column names
        /// </summary>
        /// <param name="table">string representation of the name of the table to be inserted to</param>
        /// <param name="columns">Collection containing the names of each column</param>
        /// <returns>IValuesBuilder</returns>
        public static IValuesBuilder InsertInto(string table, IEnumerable<string> columns = null)
        {
            return new InsertBuilder(table, columns);
        }

        /// <inheritdoc/>
        public IValuesBuilder Value(object value)
        {
            _values.Add(value);
            return this;
        }

        /// <inheritdoc/>
        public ISqlQueryBuilder Values(IEnumerable<object> values)
        {
            AppendValues(values);
            return this;
        }
        /// <inheritdoc/>
        public string Build()
        {
            if (_values.Count() > 0)
            {
                AppendValues(_values);
            }
            _sql.Append(";");
            return _sql.ToString();
        }

        private void AppendColumns(IEnumerable<string> columns)
        {
            _sql.Append("(");
            foreach (var column in columns)
            {
                _sql.Append($"{column}, ");
            }
            _sql.RemoveTrailingComma();
            _sql.Append(") ");
        }

        private void AppendValues(IEnumerable<object> values)
        {
            foreach (var value in values)
            {
                if (value != null)
                {
                    _sql.Append($"{value.ToSqlParameter()}, ");
                }
                else
                {
                    _sql.Append($"NULL, ");
                }
                
            }
            _sql.RemoveTrailingComma();
            _sql.Append(") ");
        }
    }
}
