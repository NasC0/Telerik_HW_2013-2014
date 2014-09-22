using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    public class HTMLElement : HTMLObject, IElement
    {
        private List<IElement> childElements;

        public HTMLElement(string name)
            :base(name)
        {
            this.childElements = new List<IElement>();
        }

        public HTMLElement(string name, string content)
            :this(name)
        {
            this.TextContent = content;
        }

        public string TextContent { get; set; }

        public IEnumerable<IElement> ChildElements
        {
            get
            {
                return this.childElements;
            }
        }

        public void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public void Render(StringBuilder output)
        {
            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                output.AppendFormat("<{0}>", this.Name);
            }

            if (this.TextContent != null)
            {
                for (int i = 0; i < TextContent.Length; i++)
                {
                    switch (TextContent[i])
                    {
                        case '<':
                            {
                                output.Append("&lt;");
                                break;
                            }
                        case '>':
                            {
                                output.Append("&gt;");
                                break;
                            }
                        case '&':
                            {
                                output.Append("&amp;");
                                break;
                            }
                        default:
                            output.Append(TextContent[i]);
                            break;
                    }
                }
            }

            foreach (var element in this.ChildElements)
            {
                element.Render(output);
            }

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                output.AppendFormat("</{0}>", this.Name);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            this.Render(result);

            return result.ToString();
        }
    }
}