using System.Collections.Generic;

using Wintellect.PowerCollections;

namespace CompanyArticles
{
    public class ArticleData
    {
        private OrderedMultiDictionary<decimal, Article> elements;

        public ArticleData()
        {
            this.elements = new OrderedMultiDictionary<decimal, Article>(true);
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(Article article)
        {
            this.elements.Add(article.Price, article);
        }

        public IList<KeyValuePair<decimal, ICollection<Article>>> ArticlesInPriceRange(decimal from, decimal to)
        {
            var result = this.elements.Range(from, true, to, true).ToArray();
            return result;
        }
    }
}
