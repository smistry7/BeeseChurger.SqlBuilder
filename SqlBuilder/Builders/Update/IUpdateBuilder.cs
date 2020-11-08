using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeseChurger.SqlBuilder.Builders.Update
{
    public interface IUpdateBuilder
    {
        ISetBuilder Update(string table);
    }
    public interface ISetBuilder : ISqlQueryBuilder
    {
        ISetBuilder Set(string sets);
        IWhereBuilder Where(string where);
        IWhereBuilder Where(string field, object value);
    }
    public interface IWhereBuilder : ISqlQueryBuilder
    {
        IWhereBuilder And(string where);

        IWhereBuilder And(string field, object value);

        IWhereBuilder Or(string where);

        IWhereBuilder Or(string field, object value);
    }
}
