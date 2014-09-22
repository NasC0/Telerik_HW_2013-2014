using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WriteTitlesToConsole
{
    public class WriteTitlesToConsole
    {
        private const string RssFeedUrl = "http://forums.academy.telerik.com/feed/qa.rss";
        private const string FileLocation = "qa.xml";

        public static void Main()
        {
            // You can find the code for the HTML generation in the HomeController.cs file in the controllers folder in the second project
            // The HTML rendering logic is in the Views/Home/Index.cshtml file

            var webClient = new WebClient();
            webClient.DownloadFile(RssFeedUrl, FileLocation);
            var xmlDocument = XDocument.Load(FileLocation);
            var jsonDocument = JsonConvert.SerializeXNode(xmlDocument, Formatting.Indented);
            var jsonObject = JObject.Parse(jsonDocument);
            var questionTitles = jsonObject["rss"]["channel"]["item"].Select(x => x["title"]);

            foreach (var title in questionTitles)
            {
                Console.WriteLine(title);
            }

            var items = jsonObject["rss"]["channel"]["item"].ToString();
            var rssItems = JsonConvert.DeserializeObject<IEnumerable<RssEntry>>(items);
        }
    }
}
