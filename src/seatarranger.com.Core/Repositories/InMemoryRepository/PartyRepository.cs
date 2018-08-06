using seatarranger.com.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace seatarranger.com.Core.Repositories.InMemoryRepository
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
            if (!db.ContainsKey(model.Name))
            {
                db.Add(model.Name, model);
                return;
            }

            throw new Exception("Cannot create party that already exists.");
        }

        public void Delete(string id)
        {
            if (db.ContainsKey(id))
            {
                db.Remove(id);
                return;
            }

            throw new Exception("Cannot delete party that doesnt exists.");
        }

        public PartyEntity Read(string id)
        {
            if (db.ContainsKey(id))
            {
                return db[id];
            }

            throw new Exception("Party does not exist.");
        }

        public List<PartyEntity> ReadAll()
        {
            if (db.Count == 0)
            {
                return new List<PartyEntity>();
            }

            return db.Values.ToList();
        }

        public void Update(string id, PartyEntity model)
        {
            if (db.ContainsKey(id))
            {
                db.Remove(id);
            }

            db.Add(id, model);
        }

        public IDictionary<string, PartyEntity> DbContext => db;
    }
}