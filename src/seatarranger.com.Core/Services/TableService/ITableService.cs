using System.Collections.Generic;
using seatarranger.com.Core.Models;

namespace seatarranger.com.Core.Services.TableService
{
    public interface ITableService
    {
        void CreateTable(TableEntity tableEntity);

        TableEntity GetTable(char id);

        List<TableEntity> GetTables();
    }
}