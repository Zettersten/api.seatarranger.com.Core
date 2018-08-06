using seatarranger.com.Core.Models;

namespace seatarranger.com.Core.Extensions
{
    public static class PartyExtensions
    {
        public static bool IsDislikedBy(this PartyEntity partyEntity, PartyEntity comparedEntity)
        {
            if (partyEntity.Dislikes == null)
            {
                return false;
            }

            if (!partyEntity.Dislikes.Contains(comparedEntity))
            {
                return false;
            }

            return true;
        }

        public static bool IsEqualTo(this PartyEntity partyEntity, PartyEntity comparedEntity)
        {
            if (partyEntity.Equals(comparedEntity))
            {
                return true;
            }

            if (partyEntity.Name != comparedEntity.Name)
            {
                return false;
            }

            if (partyEntity.Size != comparedEntity.Size)
            {
                return false;
            }

            return true;
        }
    }
}