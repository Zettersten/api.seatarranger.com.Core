using System;
using System.Collections.Generic;
using System.Text;

namespace api.seatarranger.com.Core.Models
{
    public class PartyEntity
    {
        public string Name { get; set; }

        public int Size { get; set; }

        public HashSet<PartyEntity> Dislikes { get; set; }
    }
}
