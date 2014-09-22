/* Dwarf class, extend GameObject
 * Holds the position of the playable dwarf as well as it's representation 
 * Overrides Print(), which prints the dwarf on the field */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.FallingRocks
{
    class Dwarf : GameObject
    {
        public int colTwo { get; set; }
        public int colThree { get; set; }
        public char signTwo { get; set; }
        public char signThree { get; set; }

        public Dwarf(int row, int col, ConsoleColor color, char sign)
            : base(row, col, color, sign)
        {
            this.colTwo = col - 1;
            this.colThree = col + 1;
            this.signTwo = '(';
            this.signThree = ')';
        }

        public override void Print()
        {
            base.Print();
            Console.SetCursorPosition(this.colTwo, this.row);
            Console.Write(this.signTwo);
            Console.SetCursorPosition(this.colThree, this.row);
            Console.Write(this.signThree);
        }

    }
}
