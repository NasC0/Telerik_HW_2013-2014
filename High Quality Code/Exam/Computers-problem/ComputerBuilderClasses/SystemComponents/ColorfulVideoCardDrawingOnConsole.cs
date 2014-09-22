using System;
using ComputerBuilderClasses.Contracts;

namespace ComputerBuilderClasses.SystemComponents
{
    public class ColorfulVideoCardDrawingOnConsole : IVideoCard
    {
        private const ConsoleColor DrawColor = ConsoleColor.Green;
        private const ConsoleColor DefaultColor = ConsoleColor.Gray;

        public void Draw(string dataToDraw)
        {
            Console.ForegroundColor = DrawColor;
            Console.WriteLine(dataToDraw);
            Console.ForegroundColor = DefaultColor;
        }
    }
}