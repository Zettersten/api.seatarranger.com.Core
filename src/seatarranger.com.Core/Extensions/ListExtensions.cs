using System.Collections.Generic;
using System.Linq;
using seatarranger.com.Core.Models;

namespace seatarranger.com.Core.Extensions
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