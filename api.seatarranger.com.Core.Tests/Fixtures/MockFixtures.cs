using api.seatarranger.com.Core.Models;
using System;
using System.Collections.Generic;

namespace api.seatarranger.com.Core.Tests.Fixtures
{
    public class MockFixtures : IDisposable
    {
        public TableEntity[] TableEntities
        {
            get
            {
                return new TableEntity[]
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

        public PartyEntity[] PartyEntities
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

                return new PartyEntity[]
                {
                    hoying,
                    garcia,

                    new PartyEntity
                    {
                        Name = "Owens",
                        Size = 6,
                        Dislikes = new HashSet<PartyEntity>
                        {
                            hoying,
                            taylor
                        }
                    },

                    new PartyEntity
                    {
                        Name = "Smith",
                        Size = 1,
                        Dislikes = new HashSet<PartyEntity>
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

        public Dictionary<TableEntity, PartyEntity[]> GoodResults
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

                return new Dictionary<TableEntity, PartyEntity[]>
                {
                    {
                        new TableEntity {
                            Id = 'A',
                            Capacity = 8
                        },

                        new PartyEntity[]
                        {
                            hoying,
                            taylor
                        }
                    },

                    {
                        new TableEntity
                        {
                            Id = 'B',
                            Capacity = 8
                        },

                        new PartyEntity[]
                        {
                            new PartyEntity
                            {
                                Name = "Smith",
                                Size = 1,
                                Dislikes = new HashSet<PartyEntity>
                                {
                                    garcia
                                }
                            },

                            new PartyEntity
                            {
                                Name = "Owens",
                                Size = 6,
                                Dislikes = new HashSet<PartyEntity>
                                {
                                    hoying,
                                    taylor
                                }
                            }
                        }
                    },

                    {
                        new TableEntity
                        {
                            Id = 'C',
                            Capacity = 7
                        },

                        new PartyEntity[]
                        {
                            garcia
                        }
                    },

                    {
                        new TableEntity
                        {
                            Id = 'D',
                            Capacity = 7
                        },

                        new PartyEntity[]
                        {
                            new PartyEntity
                            {
                                Name = "Reese",
                                Size = 7
                            }
                        }
                    }
                };
            }
        }

        public void Dispose()
        {
            return;
        }
    }
}