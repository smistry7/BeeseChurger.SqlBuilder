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
        [InlineData("update table set x = 1")]

        public void SelectContainingAttackShouldThrow(string injectionParam)
        {
            
            Action action1 = () => SelectBuilder.Init()
                .Select("*")
                .From("table")
                .Where($"x LIKE {injectionParam}")
                .Build();
            action1.Should().Throw<SqlInjectionException>();

            Action action2 = () => SelectBuilder.Init()
                .Select("*")
                .From("table")
                .Where("x", injectionParam)
                .Build();
            action2.Should().Throw<SqlInjectionException>();
        }
        [Theory]
        [InlineData(";DELETE FROM table;")]
        [InlineData("DROP table;")]
        [InlineData("update table set x = 1")]

        public void InsertContainingAttackShouldThrow(string injectionParam)
        {

            Action action = () => InsertBuilder
                .InsertInto("table")
                .Value(injectionParam)
                .Build();
            action.Should().Throw<SqlInjectionException>();
        }
        [Theory]
        [InlineData(";DELETE FROM table;")]
        [InlineData("DROP table;")]
        [InlineData("update table set x = 1")]

        public void UpdateContainingAttackShouldThrow(string injectionParam)
        {

            Action action = () => UpdateBuilder.Update("table")
                .Set("name", injectionParam)
                .Build();
            action.Should().Throw<SqlInjectionException>();
        }
    }
}
