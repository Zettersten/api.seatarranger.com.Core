using seatarranger.com.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace seatarranger.com.Core.Extensions
{
    public static class TableExtensions
    {
        public static bool ExeedsCapacity(this TableEntity tableEntity, PartyEntity partyEntity)
        {
            if (partyEntity == null)
            {
                return false;
            }

            return ExeedsCapacity(tableEntity, new List<PartyEntity> { partyEntity });
        }

        public static bool ExeedsCapacity(this TableEntity tableEntity, PartyEntity partyEntity, int offset)
        {
            if (partyEntity == null)
            {
                return false;
            }

            return ExeedsCapacity(tableEntity, new List<PartyEntity> { partyEntity }, offset);
        }

        public static bool ExeedsCapacity(this TableEntity tableEntity, List<PartyEntity> partyEntities)
        {
            return ExeedsCapacity(tableEntity, partyEntities, 0);
        }

        public static bool ExeedsCapacity(this TableEntity tableEntity, List<PartyEntity> partyEntities, int offset)
        {
            if (partyEntities == null)
            {
                return false;
            }

            if (partyEntities.Count == 0)
            {
                return false;
            }

            var size = partyEntities.Sum(x => x.Size) + offset;

            return size > tableEntity.Capacity;
        }

        public static bool IsEqualTo(this TableEntity tableEntity, TableEntity comparedEntity)
        {
            if (tableEntity.Equals(comparedEntity))
            {
                return true;
            }

            if (tableEntity.Id != comparedEntity.Id)
            {
                return false;
            }

            if (tableEntity.Capacity != comparedEntity.Capacity)
            {
                return false;
            }

            return true;
        }
    }
}