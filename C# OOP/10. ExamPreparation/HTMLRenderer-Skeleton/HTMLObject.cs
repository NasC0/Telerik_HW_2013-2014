using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    public abstract class HTMLObject
    {
        public HTMLObject(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
