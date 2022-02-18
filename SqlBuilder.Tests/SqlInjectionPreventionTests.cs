using BeeseChurger.SqlBuilder.Misc;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BeeseChurger.SqlBuilder.Tests
{
    public class SqlInjectionPreventionTests
    {
        [Theory]
        [InlineData(";DELETE FROM table;")]
        [InlineData("DROP table;")]
        [InlineData("'--")]
        [InlineData("';SELECT * FROM table;")]

        public void ShouldRemoveColons(string injectionParam)
        {
            
            var sql = SelectBuilder.Init()
                .Select("*")
                .From("table")
                .Where($"x LIKE {injectionParam}")
                .Build();
            sql.Should().Contain(";", Exactly.Once());

            var sql2 = SelectBuilder.Init()
                .Select("*")
                .From("table")
                .Where("x", injectionParam)
                .Build();
            sql2.Should().Contain(";", Exactly.Once());
        }
        [Theory]
        [InlineData("'@@a = 43")]

        public void AtsShouldBeRemoved(string injectionParam)
        {

            var sql = InsertBuilder
                .InsertInto("table")
                .Value(injectionParam)
                .Build();
            sql.Should().NotContain("@");
        }
        [Theory]
        [InlineData("shyam's egg")]
        public void SingleQuotesShouldBeEscaped(string injectionParam)
        {

             var sql = UpdateBuilder.Update("table")
                .Set("name", injectionParam)
                .Build();
            sql.Should().Be("UPDATE table SET name = 'shyam''s egg';");
        }
    }
}
