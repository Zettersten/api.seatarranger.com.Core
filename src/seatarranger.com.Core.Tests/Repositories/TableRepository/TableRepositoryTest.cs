using seatarranger.com.Core.Tests.Fixtures;
using Xunit;

namespace seatarranger.com.Core.Tests.Repositories.TableRepository
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