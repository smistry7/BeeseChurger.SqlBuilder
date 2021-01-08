using BeeseChurger.SqlBuilder.Builders;
using BeeseChurger.SqlBuilder.Builders.Delete;
using BeeseChurger.SqlBuilder.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeseChurger.SqlBuilder
{
    /// <summary>
    /// Fluent builder class to build a delete from SQL query.
    /// </summary>
    public sealed class DeleteBuilder : IDeleteFromBuilder, IWhereBuilder, ISqlQueryBuilder
    {
        private StringBuilder _sql;
        private DeleteBuilder(string table)
        {
            _sql = new StringBuilder();
            _sql.Append($"DELETE FROM {table} ");
        }

        /// <summary>
        /// The DeleteFrom method
        /// 
        /// To be used to initialise a new DeleteFrom SQL statement.
        /// </summary>
        /// <param name="table">string containing the table to be deleted from.</param>
        /// <returns>IDeleteFromBuilder to add to the statement.</returns>
        public static IDeleteFromBuilder DeleteFrom(string table) => new DeleteBuilder(table);


        /// <inheritdoc/>
        public IWhereBuilder Where(FormattableString where)
        {
            _sql.Append($"WHERE {where.HandleSqlInjection()} ");
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder Where(string field, object value)
        {
            if (value != null)
            {
                _sql.Append($"WHERE {field} = {value.ToSqlParameter()} ");
            }
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder And(FormattableString where)
        {
            if (_sql.ToString().Contains("WHERE"))
            {
                _sql.Append($"AND {where.HandleSqlInjection()} ");
            }
            else
            {
                Where(where);
            }

            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder And(string field, object value)
        {
            if (value != null)
            {
                if (_sql.ToString().Contains("WHERE"))
                {
                    _sql.Append($"AND {field} = {value.ToSqlParameter()} ");
                }
                else
                {
                    Where(field, value);
                }
            }
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder Or(FormattableString where)
        {
            if (_sql.ToString().Contains("WHERE"))
            {
                _sql.Append($"OR {where.HandleSqlInjection()} ");
            }
            else
            {
                Where(where);
            }
            return this;
        }

        /// <inheritdoc/>
        public IWhereBuilder Or(string field, object value)
        {
            if (value != null)
            {
                if (_sql.ToString().Contains("WHERE"))
                {
                    _sql.Append($"OR {field} = {value.ToSqlParameter()} ");
                }
                else
                {
                    Where(field, value);
                }
            }
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
