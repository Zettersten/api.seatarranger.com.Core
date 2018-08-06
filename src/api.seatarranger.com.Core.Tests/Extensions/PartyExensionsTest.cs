using api.seatarranger.com.Core.Extensions;
using api.seatarranger.com.Core.Models;
using Xunit;

namespace api.seatarranger.com.Core.Tests.Extensions
{
    public class PartyExensionsTest
    {
        [Fact]
        public void Should_Have_Truthy_Equality_Check_When_Empty()
        {
            var actual = new PartyEntity();
            var expected = new PartyEntity();

            Assert.True(actual.IsEqualTo(expected));
        }

        [Fact]
        public void Should_Have_Truthy_Equality_Check_When_Same()
        {
            var actual = new PartyEntity { Name = "Erik", Size = 1 };
            var expected = new PartyEntity { Name = "Erik", Size = 1 };

            Assert.True(actual.IsEqualTo(expected));
        }

        [Fact]
        public void Should_Not_Have_Truthy_Equality_Check_When_Size_Differs()
        {
            var actual = new PartyEntity { Name = "Erik", Size = 1 };
            var expected = new PartyEntity { Name = "Erik", Size = 2 };

            Assert.False(actual.IsEqualTo(expected));
        }

        [Fact]
        public void Should_Not_Have_Truthy_Equality_Check_When_Name_Differs()
        {
            var actual = new PartyEntity { Name = "Erik", Size = 1 };
            var expected = new PartyEntity { Name = "John", Size = 1 };

            Assert.False(actual.IsEqualTo(expected));
        }
    }
}