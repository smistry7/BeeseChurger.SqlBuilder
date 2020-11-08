namespace BeeseChurger.SqlBuilder.Builders.Insert
{
    public interface IInsertBuilder
    {
        IInsertBuilder InsertInto(string table);

        IInsertBuilder Values(object[] values);
    }
}