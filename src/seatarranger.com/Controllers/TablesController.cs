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
        private readonly IRepository<char, TableEntity> repository;

        public TablesController(ITableService tableService, IRepository<char, TableEntity> repository)
        {
            this.tableService = tableService;
            this.repository = repository;
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
            repository.Create(tableEntity);

            return tableEntity;
        }
    }
}