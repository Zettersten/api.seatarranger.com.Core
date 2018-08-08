using Microsoft.AspNetCore.Mvc;
using seatarranger.com.Core.Models;
using seatarranger.com.Core.Repositories;
using seatarranger.com.Core.Services.TableService;
using System.Collections.Generic;

namespace seatarranger.com.Controllers
{
    [Route("api/tables")]
    public class TablesController : Controller
    {
        private readonly ITableService tableService;

        public TablesController(ITableService tableService)
        {
            this.tableService = tableService;
        }

        [HttpGet]
        public IEnumerable<TableEntity> Get()
        {
            return tableService
                .GetTables();
        }

        [HttpGet("{tableId}")]
        public TableEntity Table([FromRoute] string tableId)
        {
            var id = char.Parse(tableId);

            return tableService
                .GetTable(id);
        }

        [HttpPost]
        public TableEntity Post([FromBody] TableEntity tableEntity)
        {
            tableService
                .CreateTable(tableEntity);

            return tableEntity;
        }

        [HttpDelete("{tableId}")]
        public bool Delete([FromBody] string tableId)
        {
            var id = char.Parse(tableId);

            tableService
                .DeleteTable(id);

            return true;
        }
    }
}