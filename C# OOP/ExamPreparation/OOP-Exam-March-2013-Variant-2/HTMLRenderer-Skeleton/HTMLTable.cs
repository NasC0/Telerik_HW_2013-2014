using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    public class HTMLTable : HTMLObject, ITable
    {
        private IElement[,] elements;

        public HTMLTable(int rows, int cols)
            :base("table")
        {
            this.Rows = rows;
            this.Cols = cols;
            this.elements = new IElement[rows, cols];
        }

        public int Rows { get; private set; }

        public int Cols { get; private set; }

        public IElement this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= this.elements.GetLength(0))
                {
                    throw new ArgumentOutOfRangeException("Row index was outside the bounds of the array!");
                }

                if (col < 0 || col >= this.elements.GetLength(1))
                {
                    throw new ArgumentOutOfRangeException("Column index was outside the bounds of the array!");
                }

                return this.elements[row, col];
            }
            set
            {
                if (row < 0 || row >= this.elements.GetLength(0))
                {
                    throw new ArgumentOutOfRangeException("Row index was outside the bounds of the array!");
                }

                if (col < 0 || col >= this.elements.GetLength(1))
                {
                    throw new ArgumentOutOfRangeException("Column index was outside the bounds of the array!");
                }

                this.elements[row, col] = value;
            }
        }


        public string TextContent
        {
            get
            {
                return "Tables don't have content!";
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<IElement> ChildElements
        {
            get { throw new NotImplementedException(); }
        }

        public void AddElement(IElement element)
        {
            throw new NotImplementedException();
        }

        public void Render(StringBuilder output)
        {
            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                output.AppendFormat("<{0}>", this.Name);
            }
            for (int row = 0; row < this.elements.GetLength(0); row++)
            {
                output.Append("<tr>");

                for (int col = 0; col < this.elements.GetLength(1); col++)
                {
                    output.Append("<td>");
                    this.elements[row, col].Render(output);
                    output.Append("</td>");
                }

                output.Append("</tr>");
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
