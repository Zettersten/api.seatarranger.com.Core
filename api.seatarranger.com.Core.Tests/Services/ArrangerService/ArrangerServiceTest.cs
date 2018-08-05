using api.seatarranger.com.Core.Extensions;
using api.seatarranger.com.Core.Tests.Fixtures;
using System;
using Xunit;

namespace api.seatarranger.com.Core.Tests.Services.ArrangerService
{
    public class ArrangerServiceTest : IClassFixture<ServiceFixtures>
    {
        private readonly ServiceFixtures services;

        public ArrangerServiceTest(ServiceFixtures services)
        {
            this.services = services;
        }

        [Fact]
        public void Should_Throw_Exception_On_Null_Input()
        {
            Assert.Throws<Exception>(
                testCode: () => this.services.arrangerService
                    .ArrangeParties(null, null)
            );
        }

        [Fact]
        public void Should_Throw_With_Good_Parties_And_Bad_Tables()
        {
            Assert.Throws<Exception>(
                testCode: () => this.services.arrangerService
                    .ArrangeParties(this.services.mockData.PartyEntities, null)
            );
        }

        [Fact]
        public void Should_Throw_With_Bad_Parties_And_Good_Tables()
        {
            Assert.Throws<Exception>(
                testCode: () => this.services.arrangerService
                    .ArrangeParties(null, this.services.mockData.TableEntities)
            );
        }

        [Fact]
        public void Should_Throw_When_Single_Party_Exceeds_Capacity_And_Good_Tables()
        {
            Assert.False(true);
        }

        [Fact]
        public void Should_Throw_When_Overall_Parties_Exceed_Capacity_And_Good_Tables()
        {
            Assert.False(true);
        }

        [Fact]
        public void Should_Sit_Parties_At_Tables_Without_Dislikes()
        {
            Assert.False(true);
        }

        [Fact]
        public void Should_Sit_Parties_At_Tables_With_Dislikes_Perferred()
        {
            Assert.False(true);
        }

        [Fact]
        public void Should_Sit_Parties_At_Tables_When_Dislike_Conditions_Are_Not_Met()
        {
            Assert.False(true);
        }
    }
}