using api.seatarranger.com.Core.Models;
using System;
using System.Collections.Generic;

namespace api.seatarranger.com.Core.Tests.Fixtures
{
    public class MockFixtures : IDisposable
    {
        public List<TableEntity> TableEntities
        {
            get
            {
                return new List<TableEntity>
                {
                    new TableEntity
                    {
                        Id = 'A',
                        Capacity = 8
                    },

                    new TableEntity
                    {
                        Id = 'B',
                        Capacity = 8
                    },

                    new TableEntity
                    {
                        Id = 'C',
                        Capacity = 7
                    },

                    new TableEntity
                    {
                        Id = 'D',
                        Capacity = 7
                    }
                };
            }
        }

        public List<PartyEntity> PartyEntities
        {
            get
            {
                var hoying = new PartyEntity
                {
                    Name = "Hoying",
                    Size = 3
                };

                var garcia = new PartyEntity
                {
                    Name = "Garcia",
                    Size = 2
                };

                var taylor = new PartyEntity
                {
                    Name = "Taylor",
                    Size = 5
                };

                return new List<PartyEntity>
                {
                    hoying,
                    garcia,

                    new PartyEntity
                    {
                        Name = "Owens",
                        Size = 6,
                        Dislikes = new List<PartyEntity>
                        {
                            hoying,
                            taylor
                        }
                    },

                    new PartyEntity
                    {
                        Name = "Smith",
                        Size = 1,
                        Dislikes = new List<PartyEntity>
                        {
                            garcia
                        }
                    },

                    taylor,

                    new PartyEntity
                    {
                        Name = "Reese",
                        Size = 7
                    },
                };
            }
        }
        public void Dispose()
        {
            return;
        }
    }
}