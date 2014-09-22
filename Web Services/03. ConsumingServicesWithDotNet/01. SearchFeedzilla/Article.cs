using System.Text;
using Newtonsoft.Json;
namespace SearchFeedzilla
{
    public class Article
    {
        [JsonProperty("title")]
        public string Title { get; set; }


        [JsonProperty("url")]
        public string URL { get; set; }

        public override string ToString()
        {
            StringBuilder resultString = new StringBuilder();
            resultString.AppendLine(string.Format("Title: {0}", this.Title));
            resultString.AppendLine(string.Format("Url: {0}", this.URL));
            return resultString.ToString();
        }
    }
}
