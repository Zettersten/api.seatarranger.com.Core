using seatarranger.com.Core.Extensions;
using seatarranger.com.Core.Models;
using seatarranger.com.Core.Repositories;
using System;
using System.Collections.Generic;

namespace seatarranger.com.Core.Services.TableService
{
    public class TableService : ITableService
    {
        private readonly IRepository<char, TableEntity> tableRepository;

        public TableService(IRepository<char, TableEntity> tableRepository)
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