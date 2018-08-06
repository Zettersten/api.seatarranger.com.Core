using seatarranger.com.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace seatarranger.com.Core.Repositories.InMemoryRepository
{
    public class TableRepository : IRepository<char, TableEntity>
    {
        private readonly Dictionary<char, TableEntity> db;

        public TableRepository()
        {
            this.db = new Dictionary<char, TableEntity>();
        }

        public void Create(TableEntity model)
        {
            if (!db.ContainsKey(model.Id))
            {
                db.Add(model.Id, model);
                return;
            }

            throw new Exception("Cannot create table that already exists.");
        }

        public void Delete(char id)
        {
            if (db.ContainsKey(id))
            {
                db.Remove(id);
                return;
            }

            throw new Exception("Cannot delete table that doesnt exists.");
        }

        public TableEntity Read(char id)
        {
            if (db.ContainsKey(id))
            {
                return db[id];
            }

            throw new Exception("Table does not exist.");
        }

        public List<TableEntity> ReadAll()
        {
            if (db.Count == 0)
            {
                return new List<TableEntity>();
            }

            return db.Values.ToList();
        }

        public void Update(char id, TableEntity model)
        {
            if (db.ContainsKey(id))
            {
                db.Remove(id);
            }

            db.Add(id, model);
        }

        public IDictionary<char, TableEntity> DbContext => db;
    }
}