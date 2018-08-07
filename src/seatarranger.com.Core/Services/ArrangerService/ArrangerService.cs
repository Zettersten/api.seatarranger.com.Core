using seatarranger.com.Core.Extensions;
using seatarranger.com.Core.Models;
using System;
using System.Collections.Generic;

namespace seatarranger.com.Core.Services.ArrangerService
{
    public class ArrangerService : IArrangerService
    {
        public Dictionary<TableEntity, List<PartyEntity>> ArrangeParties(List<PartyEntity> partyEntities, List<TableEntity> tableEntities)
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

            if (tableEntities.Count == 0)
            {
                throw new Exception("There must be atleast 1 table to arrange parties.");
            }

            if (partyEntities.Count == 0)
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
            var finalResult = new Dictionary<TableEntity, List<PartyEntity>>();
            var sortedParties = partyEntities.SortByLargestPartyFirst();
            var sortedTables = tableEntities.SortByLargestTableFirst();

            /**
             * Track last added table
             */
            var addedParties = new HashSet<PartyEntity>();
            PartyEntity lastAddedParty = null;

            for (int tableIndex = 0; tableIndex < sortedTables.Count; tableIndex++)
            {
                var table = sortedTables[tableIndex];
                var currentSize = 0;

                /**
                 * Define table for final result output
                 */
                if (!finalResult.ContainsKey(table))
                {
                    finalResult.Add(table, new List<PartyEntity>());
                }

                for (int partyIndex = 0; partyIndex < sortedParties.Count; partyIndex++)
                {
                    var party = sortedParties[partyIndex];

                    /**
                     *  Party has already been sat. Skip to next...
                     */
                    if (addedParties.Contains(party))
                    {
                        continue;
                    }

                    /**
                     * This party ain't gonna work here...
                     *  - We throw exception becuase we know that parties and tables are
                     *    ordered from largest to smallest.
                     */
                    if (table.ExeedsCapacity(party))
                    {
                        throw new Exception($"The party {party.Name} ({party.Size}) was too large to accommodate.");
                    }

                    /**
                     * Exceeded table capacity
                     */
                    if (table.ExeedsCapacity(party, currentSize))
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

            if (sortedParties.Count != addedParties.Count)
            {
                throw new Exception("All parties must be assigned to tables.");
            }

            #endregion Algorithm

            return finalResult;
        }
    }
}