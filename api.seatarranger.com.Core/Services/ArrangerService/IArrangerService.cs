using api.seatarranger.com.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.seatarranger.com.Core.Services.ArrangerService
{
    public interface IArrangerService
    {
        Dictionary<TableEntity, HashSet<PartyEntity>> ArrangeParties(PartyEntity[] partyEntities, TableEntity[] tableEntities);
    }
}
