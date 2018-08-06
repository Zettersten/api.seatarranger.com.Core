using System.Collections.Generic;
using System.Linq;
using api.seatarranger.com.Core.Models;

namespace api.seatarranger.com.Core.Extensions
{
    public static class ListExtensions
    {
        public static List<PartyEntity> SortByLargestPartyFirst(this List<PartyEntity> partyEntities)
        {
            return partyEntities
                .OrderByDescending(x =>  x.Size)
                .ToList();
        }
        
        public static List<TableEntity> SortByLargestTableFirst(this List<TableEntity> tableEntities)
        {
            return tableEntities
                .OrderByDescending(x =>  x.Capacity)
                .ToList();
        }
    }
}