using api.seatarranger.com.Core.Models;
using System;
using System.Collections.Generic;

namespace api.seatarranger.com.Core.Repositories.InMemoryRepository
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
            throw new NotImplementedException();
        }

        public void Delete(char id)
        {
            throw new NotImplementedException();
        }

        public TableEntity Read(char id)
        {
            throw new NotImplementedException();
        }

        public TableEntity[] ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(char id, TableEntity model)
        {
            throw new NotImplementedException();
        }

        public IDictionary<char, TableEntity> DbContext => db;
    }
}