using api.seatarranger.com.Core.Extensions;
using api.seatarranger.com.Core.Models;
using Xunit;

namespace api.seatarranger.com.Core.Tests.Extensions
{
    public class TableExtensionsTest
    {
        [Fact]
        public void Should_Have_Truthy_Equality_Check_When_Empty()
        {
            var actual = new TableEntity();
            var expected = new TableEntity();

            Assert.True(actual.IsEqualTo(expected));
        }

        [Fact]
        public void Should_Have_Truthy_Equality_Check_When_Same()
        {
            var actual = new TableEntity { Id = 'A', Capacity = 1 };
            var expected = new TableEntity { Id = 'A', Capacity = 1 };

            Assert.True(actual.IsEqualTo(expected));
        }

        [Fact]
        public void Should_Not_Have_Truthy_Equality_Check_When_Size_Differs()
        {
            var actual = new TableEntity { Id = 'B', Capacity = 1 };
            var expected = new TableEntity { Id = 'B', Capacity = 2 };

            Assert.False(actual.IsEqualTo(expected));
        }

        [Fact]
        public void Should_Not_Have_Truthy_Equality_Check_When_Name_Differs()
        {
            var actual = new TableEntity { Id = 'C', Capacity = 1 };
            var expected = new TableEntity { Id = 'D', Capacity = 1 };

            Assert.False(actual.IsEqualTo(expected));
        }
    }
}