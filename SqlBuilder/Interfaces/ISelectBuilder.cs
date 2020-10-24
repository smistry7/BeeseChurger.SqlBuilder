using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{
    public interface ISelectBuilder
    {
        IFromBuilder Select(string select);
    }
    public interface IFromBuilder
    {
        IFromBuilder From(string table);
        IWhereBuilder Where(string where);
        IJoinBuilder InnerJoin(string joiningTable);
        IJoinBuilder RightJoin(string joiningTable);
        IJoinBuilder LeftJoin(string joiningTable);
        IOrderByBuilder OrderBy(string field);
    }
    public interface IWhereBuilder
    {
        IWhereBuilder And(string where);
        IWhereBuilder Or(string where);
    }

    public interface IJoinBuilder
    {
        IFromBuilder On(string on);
    }
    public interface IOrderByBuilder
    {
        IFromBuilder Ascending();
        IFromBuilder Descending();
    }
    public interface IInsertBuilder
    {
        IInsertBuilder InsertInto(string table);
        IInsertBuilder Values(object[] values);
        

    }
}
