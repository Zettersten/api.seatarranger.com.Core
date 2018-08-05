using api.seatarranger.com.Core.Extensions;
using api.seatarranger.com.Core.Models;
using api.seatarranger.com.Core.Repositories.InMemoryRepository;
using System;
using System.Collections.Generic;

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
            #region Validation

            if (partyEntity.Size == 0)
            {
                throw new Exception("Cannot create a party with a size of zero.");
            }

            if (string.IsNullOrWhiteSpace(partyEntity.Name))
            {
                throw new Exception("Cannot create a party with no name.");
            }

            #endregion Validation

            this.CreateParty(partyEntity);
        }

        public List<PartyEntity> GetParties()
        {
            return this.partyRepository
                .ReadAll()
                .SortByLargestPartyFirst();
        }

        public PartyEntity GetParty(string name)
        {
            return this.GetParty(name);
        }
    }
}