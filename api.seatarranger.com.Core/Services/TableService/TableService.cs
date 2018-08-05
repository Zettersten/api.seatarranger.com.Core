using api.seatarranger.com.Core.Extensions;
using api.seatarranger.com.Core.Models;
using api.seatarranger.com.Core.Repositories.InMemoryRepository;
using System;
using System.Collections.Generic;

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
            #region Validation

            if (tableEntity.Capacity == 0)
            {
                throw new Exception("Cannot create a table with a capacity of zero.");
            }

            if (!char.IsLetter(tableEntity.Id))
            {
                throw new Exception("Cannot create a table with ID that is not a letter.");
            }

            if (!char.IsUpper(tableEntity.Id))
            {
                throw new Exception("Cannot create a table with a lowercase tabel ID.");
            }

            #endregion Validation

            this.tableRepository.Create(tableEntity);
        }

        public TableEntity GetTable(char id)
        {
            return this.tableRepository.Read(id);
        }

        public List<TableEntity> GetTables()
        {
            return this.tableRepository
                .ReadAll()
                .SortByLargestTableFirst();
        }
    }
}