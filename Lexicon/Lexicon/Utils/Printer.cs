namespace Lexicon.Utils
{
    using System;

    public static class Printer
    {
        public static void PrintText(string text, ConsoleColor color)
        {
            Console.Clear();
            Console.ForegroundColor = color;
            Console.SetCursorPosition(5, 10);
            Console.WriteLine(text);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;

        }

        public static void PrintMenuOption(string textLine,int xCoordinate, int yCoordinate, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(xCoordinate, yCoordinate);
            Console.WriteLine(textLine);
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
    }
}
