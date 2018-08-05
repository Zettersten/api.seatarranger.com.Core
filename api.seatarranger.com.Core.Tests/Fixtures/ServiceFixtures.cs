using api.seatarranger.com.Core.Repositories.InMemoryRepository;
using api.seatarranger.com.Core.Services.ArrangerService;
using api.seatarranger.com.Core.Services.PartyService;
using api.seatarranger.com.Core.Services.TableService;
using System;

namespace api.seatarranger.com.Core.Tests.Fixtures
{
    public class ServiceFixtures : IDisposable
    {
        public readonly IArrangerService arrangerService;
        public readonly IPartyService partyService;
        public readonly ITableService tableService;
        public readonly MockFixtures mockData;

        public ServiceFixtures()
        {
            this.arrangerService = new ArrangerService();
            this.partyService = new PartyService(new PartyRepository());
            this.tableService = new TableService(new TableRepository());
            this.mockData = new MockFixtures();
        }

        public void Dispose()
        {
            return;
        }
    }
}