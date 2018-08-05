﻿using api.seatarranger.com.Core.Models;

namespace api.seatarranger.com.Core.Services.PartyService
{
    public interface IPartyService
    {
        void CreateParty(PartyEntity partyEntity);

        PartyEntity GetParty(string name);

        PartyEntity[] GetParties();
    }
}