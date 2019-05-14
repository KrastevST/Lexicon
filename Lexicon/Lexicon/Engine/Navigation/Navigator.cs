namespace Lexicon.Engine.Navigation
{
    using Lexicon.Engine.Contracts;
    using Lexicon.Engine.DataCollection;
    using Lexicon.Models.Contracts;
    using Lexicon.Models.Database;
    using Lexicon.Models.Menus;
    using System;

    public class Navigator : INavigator
    {
        private IMenu menu;
        private IMenuSlide currentMenuSlide;
        private int newSlideId;

        public Navigator()
        {
            this.menu = new Menu();
            this.newSlideId = 1;
            this.currentMenuSlide = this.menu.GetSlideById(newSlideId);
        }

        private int NewSlideId
        {
            get => newSlideId;
            set
            {
                if (value > 1)
                {
                    newSlideId = value;
                }
            }
        }

        public void Start()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.CursorVisible = false;
            ListOfPeople.Load();
            RefreshTheDisplay(currentMenuSlide);

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
            RefreshTheDisplay(currentMenuSlide);
        }

        private void SwitchDownwards()
        {
            this.currentMenuSlide.SelectedOption--;
            RefreshTheDisplay(currentMenuSlide);
        }

        private void EnterSelectedOption()
        {
            // Id is the numeric pathway from main menu to the slide
            NewSlideId = currentMenuSlide.Id * 10 + currentMenuSlide.SelectedOption;

            switch (NewSlideId)
            {
                case 10:
                    ListOfPeople.Save();
                    Environment.Exit(0);
                    break;
                case 11:
                    var qMaster = new QuizMaster();
                    qMaster.CollectData();
                    qMaster.StartQuiz();
                    ReturnToPreviousMenu();
                    break;
                default:
                    currentMenuSlide = menu.GetSlideById(newSlideId);
                    RefreshTheDisplay(currentMenuSlide);
                    break;
            }
        }

        private void ReturnToPreviousMenu()
        {
            NewSlideId = currentMenuSlide.Id / 10;
            currentMenuSlide = menu.GetSlideById(newSlideId);
            RefreshTheDisplay(currentMenuSlide);

        }

        private void RefreshTheDisplay(IMenuSlide menuSlide)
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");

            for (int i = menuSlide.Options.Length - 1; i >= 0; i--)
            {
                if (i == menuSlide.SelectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;

                    string textLine = $"-->{menuSlide.Options[i]}<--";
                    // Center the text
                    Console.SetCursorPosition(((Console.WindowWidth - textLine.Length) / 2),
                        Console.CursorTop);
                    Console.WriteLine(textLine);

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    string textLine = menuSlide.Options[i];
                    // Center the text
                    Console.SetCursorPosition((Console.WindowWidth - textLine.Length) / 2,
                        Console.CursorTop);
                    Console.WriteLine(textLine);
                }
            }
        }
    }
}
