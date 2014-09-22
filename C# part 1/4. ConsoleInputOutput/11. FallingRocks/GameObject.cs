/* GameObject class, holds the position, color and sign of a rock
 * Has Print() method which prints the object based on it's position */

using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.FallingRocks
{
    class GameObject
    {
        public int row { get; set; }
        public int col { get; set; }
        public ConsoleColor color { get; set; }
        public char sign { get; set; }

        public GameObject(int row, int col, ConsoleColor color, char sign)
        {
            this.row = row;
            this.col = col;
            this.color = color;
            this.sign = sign;
        }

        public virtual void Print()
        {
            Console.SetCursorPosition(this.col, this.row);
            Console.ForegroundColor = this.color;
            Console.Write(this.sign);
        }
    }
}
