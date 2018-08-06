using api.seatarranger.com.Core.Models;
using api.seatarranger.com.Core.Repositories;
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