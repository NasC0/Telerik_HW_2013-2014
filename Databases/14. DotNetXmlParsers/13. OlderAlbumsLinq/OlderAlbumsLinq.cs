using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OlderAlbumsLinq
{
    public class OlderAlbumsLinq
    {
        private const string FileLocation = "../../../catalogue.xml";
        private const int YearRange = 5;

        public static void Main()
        {
            var musicCatalogue = XDocument.Load(FileLocation);

            var dateRange = DateTime.Now.Year - YearRange;

            var albumPrices = musicCatalogue.Descendants("year")
                                            .Where(x => int.Parse(x.Value) > dateRange)
                                            .Select(x => new
                                            {
                                                Price = x.Parent.Descendants("price").FirstOrDefault().Value
                                            });

            foreach (var item in albumPrices)
            {
                Console.WriteLine(item.Price);
            }
        }
    }
}
