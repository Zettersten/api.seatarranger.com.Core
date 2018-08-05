using api.seatarranger.com.Core.Models;

namespace api.seatarranger.com.Core.Extensions
{
    public static class TableExtensions
    {
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