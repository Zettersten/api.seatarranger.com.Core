using api.seatarranger.com.Core.Models;
using System;
using System.Collections.Generic;

namespace api.seatarranger.com.Core.Tests.Fixtures
{
    public class MockFixtures : IDisposable
    {
        public List<TableEntity> Mock_Tables_Good
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

        public List<PartyEntity> Mock_Parties_Good
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

        public List<PartyEntity> Mock_Parties_Bad_Single_Too_Large
        {
            get
            {
                return new List<PartyEntity>
                {
                    new PartyEntity
                    {
                        Name = "Does not matter",
                        Size = 99
                    }
                };
            }
        }

        public List<PartyEntity> Mock_Parties_Bad_Single_Later_In_List_Too_Large
        {
            get
            {
                return new List<PartyEntity>
                {
                    new PartyEntity
                    {
                        Name = "Test",
                        Size = 2
                    },

                    new PartyEntity
                    {
                        Name = "Does not matter",
                        Size = 99
                    }
                };
            }
        }

        public List<PartyEntity> Mock_Parties_Bad_Too_Many_Entries
        {
            get
            {
                var result = Mock_Parties_Good;

                result.
                    Add(new PartyEntity
                    {
                        Name = "Richard",
                        Size = 2
                    });

                result.
                    Add(new PartyEntity
                    {
                        Name = "Erik",
                        Size = 5
                    });

                result.
                    Add(new PartyEntity
                    {
                        Name = "Wendy",
                        Size = 1
                    });

                return result;
            }
        }

        public void Dispose()
        {
            return;
        }
    }
}