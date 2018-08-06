using System.Collections.Generic;

namespace seatarranger.com.Core.Models
{
    public class PartyEntity
    {
        public string Name { get; set; }

        public int Size { get; set; }

        public List<PartyEntity> Dislikes { get; set; }
    }
}