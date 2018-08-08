using Microsoft.AspNetCore.Mvc;
using seatarranger.com.Core.Models;
using seatarranger.com.Core.Repositories;
using seatarranger.com.Core.Services.PartyService;
using System.Collections.Generic;

namespace seatarranger.com.Controllers
{
    [Route("api/parties")]
    public class PartiesController : Controller
    {
        private readonly IPartyService partyService;

        public PartiesController(IPartyService partyService)
        {
            this.partyService = partyService;
        }

        [HttpGet]
        public IEnumerable<PartyEntity> Get()
        {
            return partyService
                .GetParties();
        }

        [HttpGet("{partyName}")]
        public PartyEntity Party([FromRoute] string partyName)
        {
            return partyService
                .GetParty(partyName);
        }

        [HttpPost]
        public PartyEntity Post([FromBody] PartyEntity partyEntity)
        {
            partyService
                .CreateParty(partyEntity);

            return partyEntity;
        }

        [HttpDelete("{partyName}")]
        public bool Delete([FromBody] string partyName)
        {
            partyService
                .DeleteParty(partyName);

            return true;
        }
    }
}