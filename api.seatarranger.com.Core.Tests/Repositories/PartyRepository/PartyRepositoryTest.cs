using api.seatarranger.com.Core.Tests.Fixtures;
using Xunit;

namespace api.seatarranger.com.Core.Tests.Repositories.PartyRepository
{
    public class PartyRepositoryTest : IClassFixture<ServiceFixtures>
    {
        private readonly ServiceFixtures services;

        public PartyRepositoryTest(ServiceFixtures services)
        {
            this.services = services;
        }
    }
}