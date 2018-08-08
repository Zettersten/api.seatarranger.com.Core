using seatarranger.com.Core.Models;
using System.Collections.Generic;

namespace seatarranger.com.Core.Services.TableService
{
    public interface ITableService
    {
        void CreateTable(TableEntity tableEntity);

        TableEntity GetTable(char id);

        List<TableEntity> GetTables();

        void Clear();

        void DeleteTable(char id);
    }
}