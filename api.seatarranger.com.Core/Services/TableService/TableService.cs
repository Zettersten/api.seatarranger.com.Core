using System;
using System.Collections.Generic;
using System.Text;
using api.seatarranger.com.Core.Models;
using api.seatarranger.com.Core.Repositories.InMemoryRepository;

namespace api.seatarranger.com.Core.Services.TableService
{
    public class TableService : ITableService
    {
        private readonly TableRepository tableRepository;

        public TableService(TableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        public void CreateTable(TableEntity tableEntity)
        {
            throw new NotImplementedException();
        }

        public TableEntity GetTable(char id)
        {
            throw new NotImplementedException();
        }

        public TableEntity[] GetTables()
        {
            throw new NotImplementedException();
        }
    }
}
