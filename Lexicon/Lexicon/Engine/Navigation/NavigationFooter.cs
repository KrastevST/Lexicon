namespace Lexicon.Engine.Navigation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NavigationFooter
    {
        public void Display()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight - 2);
            Console.WriteLine("Press Enter to try again");
            Console.WriteLine("Press ESC to return to main menu");
        }
        public bool IsRepeating()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            bool result = false;

            switch (info.Key)
            {
                case ConsoleKey.Enter:
                    result = true;
                    break;
                case ConsoleKey.Escape:
                    result = false;
                    break;
            }

            return result;
        }
    }
}
