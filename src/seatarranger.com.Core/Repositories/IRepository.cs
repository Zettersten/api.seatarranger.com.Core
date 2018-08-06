using System.Collections.Generic;

namespace seatarranger.com.Core.Repositories
{
    public interface IRepository<S, T>
        where T : class
    {
        void Create(T model);

        T Read(S id);

        void Update(S id, T model);

        void Delete(S id);

        List<T> ReadAll();

        IDictionary<S, T> DbContext { get; }
    }
}