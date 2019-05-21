namespace Lexicon.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Formatter
    {
        public static void FormatConsoleWindow()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.CursorVisible = false;
            Console.SetWindowSize(90, 30);
        }

        public static string FormatName(string name)
        {
            string result = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            return result;
        }
    }
}
