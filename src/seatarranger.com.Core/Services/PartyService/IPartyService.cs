using System.Collections.Generic;
using seatarranger.com.Core.Models;

namespace seatarranger.com.Core.Services.PartyService
{
    public interface IPartyService
    {
        void CreateParty(PartyEntity partyEntity);

        PartyEntity GetParty(string name);

        List<PartyEntity> GetParties();
    }
}