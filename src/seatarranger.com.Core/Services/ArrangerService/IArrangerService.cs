using seatarranger.com.Core.Models;
using System.Collections.Generic;

namespace seatarranger.com.Core.Services.ArrangerService
{
    public interface IArrangerService
    {
        Dictionary<TableEntity, List<PartyEntity>> ArrangeParties(List<PartyEntity> partyEntities, List<TableEntity> tableEntities);
    }
}