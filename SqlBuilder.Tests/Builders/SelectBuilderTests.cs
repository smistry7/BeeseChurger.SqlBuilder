using FluentAssertions;
using System;
using Xunit;

namespace BeeseChurger.SqlBuilder.Tests.Builders
{
    public class SelectBuilderTests
    {
        [Fact]
        public void BuildReturnsCorrectString()
        {
            var builder = SelectBuilder
                .Init()
                .Select("*")
                .From("table")
                .Where("x", 2)
                .And($"y = 'John'");
            builder.Build().Should().Be("SELECT * FROM table WHERE x = 2 AND y = 'John' ;");
        }

        [Fact]
        public void BuildReturnsCorrectStringWithJoin()
        {
            var builder = SelectBuilder
                .Init()
                .Select("*")
                .From("table1 t1")
                .InnerJoin("table2 t2")
                .On("t1.name = t2.name");
            builder.Build().Should().Be("SELECT * FROM table1 t1 INNER JOIN table2 t2 ON t1.name = t2.name ;");
        }

        [Fact]
        public void BuildReturnsCorrectStringWithOrderBy()
        {
            var builder = SelectBuilder
                .Init()
                .Select("*")
                .From("table1")
                .Where($"id = 1")
                .OrderBy("AddedDate")
                .Ascending();
            builder.Build().Should().Be("SELECT * FROM table1 WHERE id = 1 ORDER BY AddedDate ASC ;");
        }

        [Fact]
        public void BuildReturnsCorrectStringWithAndOr()
        {
            var a = "xyz";
            var builder = SelectBuilder
                .Init()
                .Select("*")
                .From("wherever")
                .Where($"abc = {a}")
                .And($"cor = 12")
                .Or($"x LIKE 'sad'");

            builder.Build().Should().Be("SELECT * FROM wherever WHERE abc = 'xyz' AND cor = 12 OR x LIKE 'sad' ;");
        }

        [Fact]
        public void BuildReturnsCorrectStringKitchenSink()
        {
            var builder = SelectBuilder
                .Init()
                .Select("t1.blah")
                .From("table1 t1")
                .InnerJoin("table2 t2")
                .On("t1.id = t2.t1Id")
                .LeftJoin("table3 t3")
                .On("t1.id = t3.t1Id")
                .Where($"t1.id = 4")
                .And($"t1.name like 'Shyam'")
                .OrderBy("t2.field")
                .Ascending();
            builder.Build().Should()
                .Be("SELECT t1.blah FROM table1 t1 INNER JOIN table2 t2 ON t1.id = t2.t1Id " +
                "LEFT JOIN table3 t3 ON t1.id = t3.t1Id WHERE t1.id = 4 AND t1.name like 'Shyam' ORDER BY t2.field ASC ;");
        }

        [Fact]
        public void BuildReturnsCorrectStringWithAlternateWhere()
        {
            var dateTime = DateTime.Now;
            var builder = SelectBuilder
                .Init()
                .Select("*")
                .From("table")
                .Where("x", 5)
                .And("y", "john")
                .Or("z", dateTime);
            builder.Build().Should().Be($"SELECT * FROM table WHERE x = 5 AND y = 'john' OR z = '{dateTime.ToString("yyyy-MM-dd h:mm tt")}' ;");
        }
        [Fact]
        public void BuildReturnsCorrectStringWithPagination()
        {
            var builder = SelectBuilder
                .Init()
                .Select("*")
                .From("table")
                .Where("x", 3)
                .Paginate(1, 2);
            builder.Build().Should().Be("SELECT * FROM table WHERE x = 3 OFFSET 0 ROWS FETCH NEXT 2 ROWS ONLY ;");
        }
        [Fact]
        public void BuildReturnsCorrectStringWithMultipleSelects()
        {
            var builder = SelectBuilder
                .Init()
                .Select("name")
                .Select("age")
                .Select("DateOfBirth")
                .From("people")
                .Where("age", 24);
            builder.Build().Should().Be("SELECT name, age, DateOfBirth FROM people WHERE age = 24 ;");
        }
        [Fact]
        public void BuildReturnsCorrectStringWithNullWhere()
        {
            var builder = SelectBuilder.Init()
                .Select("*")
                .From("table")
                .Where("a", null)
                .And("b", 1);

            builder.Build().Should().Be("SELECT * FROM table WHERE b = 1 ;");
        }
    }
}