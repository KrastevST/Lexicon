namespace Lexicon
{
    using Lexicon.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Navigator
    {
        private static IMenu mainManu = new Menu ("MainMenu", new string[] { "Exit", "Take the quiz", "View profiles" });
        private IMenu currentMenu = mainManu;

        public void Start()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            RefreshTheDisplay(currentMenu);

            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.UpArrow)
                {
                    SwitchUpwards();
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    SwitchDownwards();
                }
                else if (info.Key == ConsoleKey.Enter)
                {
                    EnterSelectedOption();
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    ReturnToPreviousMenu();
                }
            }
        }

        private void SwitchUpwards()
        {
            this.currentMenu.SelectedOption++;
            RefreshTheDisplay(currentMenu);
        }

        private void SwitchDownwards()
        {
            this.currentMenu.SelectedOption--;
            RefreshTheDisplay(currentMenu);
        }

        private void EnterSelectedOption()
        {
           
        }

        private void ReturnToPreviousMenu()
        {
            throw new NotImplementedException();
        }

        private void RefreshTheDisplay(IMenu menu)
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");

            for (int i = menu.Options.Length - 1; i >= 0; i--)
            {
                if (i == menu.SelectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;

                    string textLine = $"-->{menu.Options[i]}<--";
                    // Center the text
                    Console.SetCursorPosition(((Console.WindowWidth - textLine.Length) / 2),
                        Console.CursorTop);
                    Console.WriteLine(textLine);

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    string textLine = menu.Options[i];
                    // Center the text
                    Console.SetCursorPosition((Console.WindowWidth - textLine.Length) / 2,
                        Console.CursorTop);
                    Console.WriteLine(textLine);
                }
            }
        }
    }
}
