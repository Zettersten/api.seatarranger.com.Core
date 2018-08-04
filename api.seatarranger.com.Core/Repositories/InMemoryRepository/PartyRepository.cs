using api.seatarranger.com.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.seatarranger.com.Core.Repositories.InMemoryRepository
{
    public class PartyRepository : IRepository<string, PartyEntity>
    {
        private readonly Dictionary<string, PartyEntity> db;

        public PartyRepository()
        {
            this.db = new Dictionary<string, PartyEntity>();
        }

        public void Create(PartyEntity model)
        {
            throw new NotImplementedException();
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }

        public PartyEntity Read(string name)
        {
            throw new NotImplementedException();
        }

        public PartyEntity[] ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(string name, PartyEntity model)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, PartyEntity> DbContext => db;
    }
}
