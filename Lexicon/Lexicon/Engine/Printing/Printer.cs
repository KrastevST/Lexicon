namespace Lexicon.Engine.Printing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Printer
    {
        public static void PrintQuestion(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(5, 10);
            Console.WriteLine(text);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;

        }
    }
}
