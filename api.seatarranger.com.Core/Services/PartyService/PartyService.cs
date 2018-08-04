using System;
using System.Collections.Generic;
using System.Text;
using api.seatarranger.com.Core.Models;
using api.seatarranger.com.Core.Repositories.InMemoryRepository;

namespace api.seatarranger.com.Core.Services.PartyService
{
    public class PartyService : IPartyService
    {
        private readonly PartyRepository partyRepository;

        public PartyService(PartyRepository partyRepository)
        {
            this.partyRepository = partyRepository;
        }

        public void CreateParty(PartyEntity partyEntity)
        {
            throw new NotImplementedException();
        }

        public PartyEntity[] GetParties()
        {
            throw new NotImplementedException();
        }

        public PartyEntity GetParty(string name)
        {
            throw new NotImplementedException();
        }
    }
}
