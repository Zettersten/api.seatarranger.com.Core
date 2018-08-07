using Microsoft.AspNetCore.Mvc;
using seatarranger.com.Core.Models;
using seatarranger.com.Core.Services.ArrangerService;
using seatarranger.com.Core.Services.PartyService;
using seatarranger.com.Core.Services.TableService;
using System.Collections.Generic;

namespace seatarranger.com.Controllers
{
    [Route("api/arrangements")]
    public class ArrangementsController : Controller
    {
        private readonly IArrangerService arrangerService;
        private readonly IPartyService partyService;
        private readonly ITableService tableService;

        public ArrangementsController(IArrangerService arrangerService, IPartyService partyService, ITableService tableService)
        {
            this.arrangerService = arrangerService;
            this.partyService = partyService;
            this.tableService = tableService;
        }

        [HttpPost]
        public Dictionary<TableEntity, List<PartyEntity>> Post()
        {
            return arrangerService
                .ArrangeParties(partyService.GetParties(), tableService.GetTables());
        }

        [HttpDelete]
        public bool Delete()
        {
            partyService.Clear();
            tableService.Clear();

            return true;
        }
    }
}