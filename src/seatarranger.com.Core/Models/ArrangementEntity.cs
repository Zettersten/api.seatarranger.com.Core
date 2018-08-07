using System.Collections.Generic;

namespace seatarranger.com.Core.Models
{
    public class ArrangementEntity
    {
        public TableEntity Table { get; set; }

        public List<PartyEntity> Parties { get; set; }
    }
}