using seatarranger.com.Core.Models;
using seatarranger.com.Core.Repositories;
using seatarranger.com.Core.Repositories.InMemoryRepository;
using seatarranger.com.Core.Services.ArrangerService;
using seatarranger.com.Core.Services.PartyService;
using seatarranger.com.Core.Services.TableService;
using System;

namespace seatarranger.com.Core.Tests.Fixtures
{
    public class ServiceFixtures : IDisposable
    {
        public readonly IArrangerService arrangerService;
        public readonly IPartyService partyService;
        public readonly ITableService tableService;

        public readonly IRepository<string, PartyEntity> partyRepository;
        public readonly IRepository<char, TableEntity> tableRepository;

        public readonly MockFixtures mockData;

        public ServiceFixtures()
        {
            this.partyRepository = new PartyRepository();
            this.tableRepository = new TableRepository();

            this.arrangerService = new ArrangerService();
            this.partyService = new PartyService(partyRepository);
            this.tableService = new TableService(tableRepository);
            this.mockData = new MockFixtures();
        }

        public void Dispose()
        {
            return;
        }
    }
}