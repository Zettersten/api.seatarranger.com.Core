using api.seatarranger.com.Core.Extensions;
using api.seatarranger.com.Core.Models;
using api.seatarranger.com.Core.Repositories;
using System;
using System.Collections.Generic;

namespace api.seatarranger.com.Core.Services.PartyService
{
    public class PartyService : IPartyService
    {
        private readonly IRepository<string, PartyEntity> partyRepository;

        public PartyService(IRepository<string, PartyEntity> partyRepository)
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

            this.partyRepository.Create(partyEntity);
        }

        public List<PartyEntity> GetParties()
        {
            return this.partyRepository
                .ReadAll()
                .SortByLargestPartyFirst();
        }

        public PartyEntity GetParty(string name)
        {
            return this.partyRepository.Read(name);
        }
    }
}