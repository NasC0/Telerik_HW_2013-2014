using System.Collections.Generic;

using BookStore.Model;

namespace BookStore.SearchByXml
{
    public interface IQueryProcessor
    {
        IEnumerable<Review> Process();
    }
}
