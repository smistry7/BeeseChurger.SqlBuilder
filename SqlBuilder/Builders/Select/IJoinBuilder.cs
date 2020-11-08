namespace BeeseChurger.SqlBuilder.Builders.Select
{
    public interface IJoinBuilder
    {
        IFromBuilder On(string on);
    }
}