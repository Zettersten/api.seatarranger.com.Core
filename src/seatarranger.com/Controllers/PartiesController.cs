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
        private readonly IRepository<string, PartyEntity> repository;

        public PartiesController(IPartyService partyService, IRepository<string, PartyEntity> repository)
        {
            this.partyService = partyService;
            this.repository = repository;
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
            repository.Create(partyEntity);

            return partyEntity;
        }
    }
}