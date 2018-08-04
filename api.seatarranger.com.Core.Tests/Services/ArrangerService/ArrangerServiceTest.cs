using api.seatarranger.com.Core.Extensions;
using api.seatarranger.com.Core.Models;
using api.seatarranger.com.Core.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void Should_Produce_Matching_Results_With_Good_Tables_And_Good_Parties()
        {
            var results = this.services.arrangerService
                .ArrangeParties(this.services.mockData.PartyEntities, this.services.mockData.TableEntities);

            var expected = this.services.mockData.GoodResults.ToJson();
            var actual = results.ToJson();

            Assert.Equal(expected, actual);
        }
    }
}
