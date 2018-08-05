using api.seatarranger.com.Core.Extensions;
using api.seatarranger.com.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var sortedParties = partyEntities.OrderByDescending(x => x.Size).ToArray();

            /**
             * Track last added table
             */
            var addedParties = new HashSet<PartyEntity>();
            PartyEntity lastAddedParty = null;

            for (int tableIndex = 0; tableIndex < tableEntities.Length; tableIndex++)
            {
                var table = tableEntities[tableIndex];
                var currentSize = 0;

                /**
                 * Define table for final result output
                 */
                if (!finalResult.ContainsKey(table))
                {
                    finalResult.Add(table, new HashSet<PartyEntity>());
                }

                for (int partyIndex = 0; partyIndex < sortedParties.Length; partyIndex++)
                {
                    var party = sortedParties[partyIndex];

                    /**
                     * This party ain't gonna work here...
                     */
                    if (party.Size > table.Capacity)
                    {
                        continue;
                    }

                    /**
                     *  Party has already been sat. Skip to next...
                     */
                    if (addedParties.Contains(party))
                    {
                        continue;
                    }

                    /**
                     * Exceeded table capacity
                     */
                    if (party.Size + currentSize > table.Capacity)
                    {
                        continue;
                    }

                    /**
                     * Can we sit the last added and current party together?
                     */
                    if (lastAddedParty != null)
                    {
                        if (lastAddedParty.IsDislikedBy(party))
                        {
                            continue;
                        }

                        if (party.IsDislikedBy(lastAddedParty))
                        {
                            continue;
                        }
                    }

                    /**
                     * Handle overall result set
                     */
                    finalResult[table].Add(party);

                    /**
                     * Track interation
                     */
                    addedParties.Add(party);
                    lastAddedParty = party;

                    currentSize = currentSize + party.Size;
                }
            }

            #endregion Algorithm

            return finalResult;
        }
    }
}