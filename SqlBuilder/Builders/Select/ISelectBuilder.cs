namespace BeeseChurger.SqlBuilder.Builders.Select
{
    public interface ISelectBuilder
    {
        ISelectBuilder Select(string select);

        IFromBuilder From(string table);
    }
}