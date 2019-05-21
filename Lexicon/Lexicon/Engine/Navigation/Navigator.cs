namespace Lexicon.Engine.Navigation
{
    using System;
    using Lexicon.Engine.Contracts;
    using Lexicon.Engine.DataCollection;
    using Lexicon.Models.Contracts;
    using Lexicon.Models.Database;
    using Lexicon.Models.Menus;
    using Lexicon.Utils;

    public class Navigator : INavigator
    {
        private IMenu menu;
        private IMenuSlide currentMenuSlide;
        private string newSlideId;
        private bool repeat = false;

        public Navigator()
        {
            this.menu = new Menu();
            this.newSlideId = "0";
            this.currentMenuSlide = this.menu.GetSlideById(newSlideId);
        }

        private string NewSlideId
        {
            get => newSlideId;
            set
            {
                if (value != "0")
                {
                    newSlideId = value;
                }
            }
        }

        public void Start()
        {
            Formatter.FormatConsoleWindow();
            ListOfPeople.Load();
            RefreshDisplayedMenu(currentMenuSlide);

            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey();

                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        SwitchUpwards();
                        break;
                    case ConsoleKey.DownArrow:
                        SwitchDownwards();
                        break;
                    case ConsoleKey.Enter:
                        EnterSelectedOption();
                        break;
                    case ConsoleKey.Backspace:
                        ReturnToPreviousMenu();
                        break;
                }
            }
        }

        private void SwitchUpwards()
        {
            this.currentMenuSlide.SelectedOption++;
            RefreshDisplayedMenu(currentMenuSlide);
        }

        private void SwitchDownwards()
        {
            this.currentMenuSlide.SelectedOption--;
            RefreshDisplayedMenu(currentMenuSlide);
        }

        private void EnterSelectedOption()
        {
            // Id is the numeric pathway from main menu to the slide
            NewSlideId = currentMenuSlide.Id + currentMenuSlide.SelectedOption;


            if (newSlideId == "00")
            {
                ListOfPeople.Save();
                Environment.Exit(0);
            }
            else if (newSlideId == "01")
            {
                var qMaster = new QuizMaster();
                do
                {

                } while (this.repeat);
                try
                {
                    qMaster.CollectPersonalData();
                }
                catch (ArgumentNullException ex)
                {
                    Printer.PrintError(ex.Message);
                    this.DisplayFooter();
                    
                }
                catch (ArgumentException ex)
                {
                }
                ReturnToPreviousMenu();
            }
            else
            {
                currentMenuSlide = menu.GetSlideById(newSlideId);
                RefreshDisplayedMenu(currentMenuSlide);
            }
        }

        private void ReturnToPreviousMenu()
        {
            NewSlideId = currentMenuSlide.Id.Substring(0, currentMenuSlide.Id.Length - 1);
            currentMenuSlide = menu.GetSlideById(newSlideId);
            RefreshDisplayedMenu(currentMenuSlide);

        }

        private void RefreshDisplayedMenu(IMenuSlide menuSlide)
        {
            Console.Clear();

            for (int i = menuSlide.Options.Length - 1; i >= 0; i--)
            {
                int yCoordinate = 10 + menuSlide.Options.Length - i;

                if (i == menuSlide.SelectedOption)
                {
                    string textLine = $"-->{menuSlide.Options[i]}<--";
                    int xCoordinate = (Console.WindowWidth - textLine.Length) / 2;

                    Printer.PrintMenuOption(textLine, xCoordinate, yCoordinate, ConsoleColor.DarkBlue);
                }
                else
                {
                    string textLine = menuSlide.Options[i];
                    int xCoordinate = (Console.WindowWidth - textLine.Length) / 2;

                    Printer.PrintMenuOption(textLine, xCoordinate, yCoordinate, ConsoleColor.DarkGreen);
                }
            }
        }

        private void DisplayFooter()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight - 2);
            Console.WriteLine("Press Enter to start over");
            Console.WriteLine("Press ESC to return to the previous menu");

            ConsoleKeyInfo info = Console.ReadKey();

            switch (info.Key)
            {
                case ConsoleKey.Enter:
                    this.repeat = true;
                    break;
                case ConsoleKey.Escape:
                    this.repeat = false;
                    break;
            }
        }
    }
}
