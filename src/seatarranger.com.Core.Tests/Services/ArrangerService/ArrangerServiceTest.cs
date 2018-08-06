using seatarranger.com.Core.Extensions;
using seatarranger.com.Core.Models;
using seatarranger.com.Core.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace seatarranger.com.Core.Tests.Services.ArrangerService
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
                    .ArrangeParties(this.services.mockData.Mock_Parties_Good, null)
            );
        }

        [Fact]
        public void Should_Throw_With_Bad_Parties_And_Good_Tables()
        {
            Assert.Throws<Exception>(
                testCode: () => this.services.arrangerService
                    .ArrangeParties(null, this.services.mockData.Mock_Tables_Good)
            );
        }

        [Fact]
        public void Should_Throw_When_Single_Party_Exceeds_Capacity_And_Good_Tables()
        {
            Assert.Throws<Exception>(
                testCode: () => this.services.arrangerService
                    .ArrangeParties(this.services.mockData.Mock_Parties_Bad_Single_Too_Large, this.services.mockData.Mock_Tables_Good)
            );
        }

        [Fact]
        public void Should_Throw_When_Single_Party_Exceed_Max_Capacity_Of_Good_Tables()
        {
            Assert.Throws<Exception>(
                testCode: () => this.services.arrangerService
                    .ArrangeParties(this.services.mockData.Mock_Parties_Bad_Single_Later_In_List_Too_Large, this.services.mockData.Mock_Tables_Good)
            );
        }

        [Fact]
        public void Should_Throw_When_There_Are_More_Parties_Than__Good_Tables()
        {
            Assert.Throws<Exception>(
                testCode: () => this.services.arrangerService
                    .ArrangeParties(this.services.mockData.Mock_Parties_Bad_Too_Many_Entries, this.services.mockData.Mock_Tables_Good)
            );
        }


        [Fact]
        public void Should_Sit_Parties_At_Tables_Without_Dislikes()
        {
            var itemToTest = this.services.arrangerService
                .ArrangeParties(this.services.mockData.Mock_Parties_Good, this.services.mockData.Mock_Tables_Good);

            var expected = false;
            var actual = false;

            foreach (var table in itemToTest)
            {
                var dislikes = new HashSet<PartyEntity>();

                foreach (var party in table.Value)
                {
                    if (dislikes.Contains(party))
                    {
                        actual = true;
                        break;
                    }

                    if (party.Dislikes == null)
                    {
                        continue;
                    }

                    foreach (var dislike in party.Dislikes)
                    {
                        dislikes.Add(dislike);
                    }
                }
            }

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Should_Sit_All_Tables()
        {
            var itemToTest = this.services.arrangerService
                .ArrangeParties(this.services.mockData.Mock_Parties_Good, this.services.mockData.Mock_Tables_Good);

            var expected = itemToTest.Count;
            var actual = this.services.mockData.Mock_Tables_Good.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Sit_At_All_Parties()
        {
            var itemToTest = this.services.arrangerService
                .ArrangeParties(this.services.mockData.Mock_Parties_Good, this.services.mockData.Mock_Tables_Good);

            var expected = this.services.mockData.Mock_Parties_Good.Count;
            var actual = itemToTest.Sum(x => x.Value.Count);

            Assert.Equal(expected, actual);
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