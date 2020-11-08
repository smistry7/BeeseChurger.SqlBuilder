namespace BeeseChurger.SqlBuilder.Builders.Select
{
    public interface IOrderByBuilder
    {
        IFromBuilder Ascending();

        IFromBuilder Descending();
    }
}