using api.seatarranger.com.Core.Models;
using System.Collections.Generic;

namespace api.seatarranger.com.Core.Services.ArrangerService
{
    public interface IArrangerService
    {
        Dictionary<TableEntity, HashSet<PartyEntity>> ArrangeParties(PartyEntity[] partyEntities, TableEntity[] tableEntities);
    }
}