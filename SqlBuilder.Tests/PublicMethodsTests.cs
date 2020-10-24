using System;
using Xunit;
using System.Reflection;
using SqlBuilder.Interfaces;
using FluentAssertions;

namespace SqlBuilder.Tests
{
    public class PublicMethodsTests
    {
        [Fact]
        public void ShouldBeAbleToFromAfterSelect()
        {
            var builder = new SelectBuilder()
                .Select("*");
            var methods = builder.GetType().GetInterface(nameof(IFromBuilder)).GetMethods(BindingFlags.Public | BindingFlags.Instance);
            methods.Should().Contain(x => x.Name == "From");
        }
    }
}
