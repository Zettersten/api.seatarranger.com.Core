using api.seatarranger.com.Core.Tests.Fixtures;
using System;
using Xunit;

namespace api.seatarranger.com.Core.Tests.Services.PartyService
{
    public class PartyServiceTest : IClassFixture<ServiceFixtures>
    {
        private readonly ServiceFixtures services;

        public PartyServiceTest(ServiceFixtures services)
        {
            this.services = services;
        }

        [Fact]
        public void Should_Create_Party()
        {
            var expected = true;
            var actual = true;

            try
            {
                this.services.partyService.CreateParty(new Models.PartyEntity
                {
                    Name = "Erik",
                    Size = 2
                });
            }
            catch
            {
                actual = false;
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Retrieve_Party_After_Create()
        {
            var name = Guid.NewGuid().ToString();

            this.services.partyService.CreateParty(new Models.PartyEntity
            {
                Name = name,
                Size = 2
            });

            var expected = name;
            var actual = "";

            try
            {
                var result = this.services.partyService
                    .GetParty(name);

                actual = result.Name;
            }
            catch { }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Retrieve_Parties_After_Create()
        {
            this.services.partyService.CreateParty(new Models.PartyEntity
            {
                Name = Guid.NewGuid().ToString(),
                Size = 1
            });

            this.services.partyService.CreateParty(new Models.PartyEntity
            {
                Name = Guid.NewGuid().ToString(),
                Size = 2
            });

            this.services.partyService.CreateParty(new Models.PartyEntity
            {
                Name = Guid.NewGuid().ToString(),
                Size = 3
            });

            var expected = 3;
            var actual = 0;

            try
            {
                var itemsToTest = this.services.partyService
                    .GetParties();

                actual = itemsToTest.Count;
            }
            catch { }

            Assert.True(expected <= actual);
        }

        [Fact]
        public void Should_Throw_Error_When_Invalid_Party()
        {
            Assert.Throws<Exception>(() =>
            {
                this.services.partyService.CreateParty(new Models.PartyEntity());
            });
        }

        [Fact]
        public void Should_Throw_Error_When_Zero_Party_Size()
        {
            Assert.Throws<Exception>(() =>
            {
                this.services.partyService.CreateParty(new Models.PartyEntity
                {
                    Name = "Ronald"
                });
            });
        }

        [Fact]
        public void Should_Throw_Error_When_Retrieving_Item_Not_Defined()
        {
            Assert.Throws<Exception>(() =>
            {
                this.services.partyService.GetParty(Guid.NewGuid().ToString());
            });
        }
    }
}