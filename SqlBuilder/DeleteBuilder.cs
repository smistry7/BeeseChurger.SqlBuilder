using BeeseChurger.SqlBuilder.Builders;
using BeeseChurger.SqlBuilder.Builders.Delete;
using BeeseChurger.SqlBuilder.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeseChurger.SqlBuilder
{
    public sealed class DeleteBuilder : IDeleteFromBuilder, IWhereBuilder, ISqlQueryBuilder
    {
        private StringBuilder _sql;
        private DeleteBuilder(string table)
        {
            _sql = new StringBuilder();
            _sql.Append($"DELETE FROM {table} ");
        }

        public static IDeleteFromBuilder DeleteFrom(string table) => new DeleteBuilder(table);


        /// <inheritdoc/>
        public IWhereBuilder Where(string where)
        {
            _sql.Append($"WHERE {where} ");
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
        public IWhereBuilder And(string where)
        {
            if (_sql.ToString().Contains("WHERE"))
            {
                _sql.Append($"AND {where} ");
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
        public IWhereBuilder Or(string where)
        {
            if (_sql.ToString().Contains("WHERE"))
            {
                _sql.Append($"OR {where} ");
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
