using System;
using ComputerBuilderSystem.Contracts;

namespace ComputerBuilderSystem.SystemComponents
{
    public class MonochromeVideoCardDrawingOnConsole : IVideoCard
    {
        private const ConsoleColor DrawColor = ConsoleColor.Gray;
        private const ConsoleColor DefaultColor = ConsoleColor.Gray;

        public void Draw(string dataToDraw)
        {
            Console.ForegroundColor = DrawColor;
            Console.WriteLine(dataToDraw);
            Console.ForegroundColor = DefaultColor;
        }
    }
}