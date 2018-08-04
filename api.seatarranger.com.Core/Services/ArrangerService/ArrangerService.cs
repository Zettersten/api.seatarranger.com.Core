using System;
using System.Collections.Generic;
using System.Text;
using api.seatarranger.com.Core.Models;

namespace api.seatarranger.com.Core.Services.ArrangerService
{
    public class ArrangerService : IArrangerService
    {
        public Dictionary<TableEntity, HashSet<PartyEntity>> ArrangeParties(PartyEntity[] partyEntities, TableEntity[] tableEntities)
        {
            #region Validation

            if (partyEntities == null)
            {
                throw new Exception("Parties cannot be null.");
            }

            if (tableEntities == null)
            {
                throw new Exception("Tables cannot be null.");
            }

            if (tableEntities.Length == 0)
            {
                throw new Exception("There must be atleast 1 table to arrange parties.");
            }

            if (partyEntities.Length == 0)
            {
                throw new Exception("There must be atleast 1 party to arrange seating.");
            }

            #endregion Validation

            #region Algorithm

            /*
             * Example:
             * 
             *  Tables: 
             *      - A-8 
             *      - B-8
             *      - C-7
             *      - D-7
             *      
             *  Parties: 
             *      - Hoying, party of 3
             *      - Garcia, party of 2
             *      - Owens, party of 6 dislikes Hoying, Taylor
             *      - Smith, party of 1 dislikes Garcia
             *      - Taylor, party of 5
             *      - Reese, party of 7
             */

            var finalResult = new Dictionary<TableEntity, HashSet<PartyEntity>>();

            

            #endregion Algorithm

            return finalResult;
        }
    }
}
