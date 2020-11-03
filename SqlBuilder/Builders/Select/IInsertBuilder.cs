namespace SqlBuilder.Interfaces
{
    public interface IInsertBuilder
    {
        IInsertBuilder InsertInto(string table);

        IInsertBuilder Values(object[] values);
    }
}