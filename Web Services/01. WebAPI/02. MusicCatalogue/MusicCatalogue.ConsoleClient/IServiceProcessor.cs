using System.Collections.Generic;

namespace MusicCatalogue.ConsoleClient
{
    public interface IServiceProcessor<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetByID(int id);

        void Add(T entry);

        void Modify(int id, T entry);

        T Delete(int id);
    }
}
