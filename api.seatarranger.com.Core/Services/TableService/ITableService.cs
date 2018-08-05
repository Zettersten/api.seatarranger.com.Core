using System.Collections.Generic;
using api.seatarranger.com.Core.Models;

namespace api.seatarranger.com.Core.Services.TableService
{
    public interface ITableService
    {
        void CreateTable(TableEntity tableEntity);

        TableEntity GetTable(char id);

        List<TableEntity> GetTables();
    }
}