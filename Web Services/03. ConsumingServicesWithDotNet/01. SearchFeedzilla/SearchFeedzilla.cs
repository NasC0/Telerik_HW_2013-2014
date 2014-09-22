using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SearchFeedzilla
{
    public class SearchFeedzilla
    {
        private const string ApiLocation = "http://api.feedzilla.com/v1/articles/search.json";

        private static IEnumerable<Article> GetArticles(HttpClient client, string queryString, int articlesCount)
        {
            var fullLocation = string.Format("{0}?{1}&count={2}", ApiLocation, queryString, articlesCount);
            var response = client.GetAsync(fullLocation).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                var articlesObject = JObject.Parse(responseContent);
                var articles = JsonConvert.DeserializeObject<IEnumerable<Article>>(articlesObject["articles"].ToString());
                return articles;
            }
            else
            {
                throw new HttpRequestException("Could not fetch results.");
            }
        }

        public static void Main()
        {
            var httpClient = new HttpClient();
            var articles = GetArticles(httpClient, "q=Michael", 5);

            foreach (var article in articles)
            {
                Console.WriteLine(article);
                Console.WriteLine();
            }
        }
    }
}
