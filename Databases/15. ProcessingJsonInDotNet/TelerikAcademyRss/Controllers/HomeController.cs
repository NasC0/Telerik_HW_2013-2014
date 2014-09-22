using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TelerikAcademyRss.Models;

namespace TelerikAcademyRss.Controllers
{
    public class HomeController : Controller
    {
        private const string RssFeedUrl = "http://forums.academy.telerik.com/feed/qa.rss";
        private const string FileLocation = "../../rss/qa.xml";

        public ActionResult Index()
        {
            var webClient = new WebClient();
            webClient.DownloadFile(RssFeedUrl, FileLocation);
            var xmlDoc = XDocument.Load(FileLocation);
            var jsonDoc = JsonConvert.SerializeXNode(xmlDoc);
            var jsonItemsArray = JObject.Parse(jsonDoc)["rss"]["channel"]["item"].ToString();
            var rssEntries = JsonConvert.DeserializeObject<IEnumerable<RssEntry>>(jsonItemsArray);

            return View(rssEntries);
        }
    }
}