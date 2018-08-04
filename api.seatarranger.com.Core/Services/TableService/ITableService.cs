using api.seatarranger.com.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.seatarranger.com.Core.Services.TableService
{
    public interface ITableService
    {
        void CreateTable(TableEntity tableEntity);

        TableEntity GetTable(char id);

        TableEntity[] GetTables();
    }
}
