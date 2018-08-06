using api.seatarranger.com.Core.Tests.Fixtures;
using Xunit;

namespace api.seatarranger.com.Core.Tests.Repositories.TableRepository
{
    public class TableRepositoryTest : IClassFixture<ServiceFixtures>
    {
        private readonly ServiceFixtures services;

        public TableRepositoryTest(ServiceFixtures services)
        {
            this.services = services;
        }
    }
}