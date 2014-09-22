using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookStore.SearchByXml
{
    public interface IQueryExtractor
    {
        IQueryProcessor DetermineQuery(XElement query);
    }
}
