using seatarranger.com.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace seatarranger.com.Core.Extensions
{
    public static class ListExtensions
    {
        public static List<PartyEntity> SortByLargestPartyFirst(this List<PartyEntity> partyEntities)
        {
            return partyEntities
                .OrderByDescending(x => x.Size)
                .ToList();
        }

        public static List<TableEntity> SortByLargestTableFirst(this List<TableEntity> tableEntities)
        {
            return tableEntities
                .OrderByDescending(x => x.Capacity)
                .ToList();
        }

        public static List<ArrangementEntity> ToJson(this Dictionary<TableEntity, List<PartyEntity>> keyValues)
        {
            var result = new List<ArrangementEntity>();

            foreach (var item in keyValues)
            {
                result.Add(new ArrangementEntity
                {
                    Table = item.Key,
                    Parties = item.Value
                });
            }

            return result;
        }
    }
}