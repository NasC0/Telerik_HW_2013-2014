using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans
{
    class HumansApplication
    {
        static void Main()
        {
        }
        
        public void CreateHuman(int age)
        {
            Human newHuman = new Human();
            newHuman.Age = age;

            if (age == 0)
            {
                newHuman.Name = "The Dudester";
                newHuman.Gender = Gender.Male;
            }
            else
            {
                newHuman.Name = "The Chick";
                newHuman.Gender = Gender.Female;
            }
        }
    }
}
