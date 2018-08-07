using seatarranger.com.Core.Models;
using System.Collections.Generic;

namespace seatarranger.com.Core.Services.PartyService
{
    public interface IPartyService
    {
        void CreateParty(PartyEntity partyEntity);

        PartyEntity GetParty(string name);

        List<PartyEntity> GetParties();

        void Clear();
    }
}