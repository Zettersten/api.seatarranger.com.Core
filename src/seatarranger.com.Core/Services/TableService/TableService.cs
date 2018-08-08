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

        public void Clear()
        {
            this.tableRepository.DbContext.Clear();
        }

        public void CreateTable(TableEntity tableEntity)
        {
            #region Validation

            if (tableEntity == null)
            {
                throw new Exception("Looks like the input provided was not suitable.");
            }

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

        public void DeleteTable(char id) => tableRepository.Delete(id);

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