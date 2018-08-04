using System;
using System.Collections.Generic;
using System.Text;

namespace api.seatarranger.com.Core.Repositories
{
    public interface IRepository<S, T>
        where T : class
    {
        void Create(T model);

        T Read(S id);

        void Update(S id, T model);

        void Delete(S id);

        T[] ReadAll();

        IDictionary<S, T> DbContext { get; }
    }
}
