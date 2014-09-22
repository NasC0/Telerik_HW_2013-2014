using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FirstRefactoringTask
{
    class UnknownClass
    {
        private const int MAX_COUNT = 6;
        class InnerClass
        {
            public void SomeFunction(bool input)
            {
                string inputAsString = input.ToString();
                Console.WriteLine(inputAsString);
            }
        }
        public static void DoWork()
        {
            UnknownClass.InnerClass innerClassInstane =
              new UnknownClass.InnerClass();
            innerClassInstane.SomeFunction(true);
        }
    }

}
