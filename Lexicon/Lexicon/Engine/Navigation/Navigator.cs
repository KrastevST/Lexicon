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
        private string newSlideId;

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
            NewSlideId = currentMenuSlide.Id + currentMenuSlide.SelectedOption;

           
            if (newSlideId == "00")
            {
                ListOfPeople.Save();
                Environment.Exit(0);
            }
            else if (newSlideId == "01")
            {
                var qMaster = new QuizMaster();
                qMaster.StartQuiz();
                ReturnToPreviousMenu();
            }
            else
            {
                currentMenuSlide = menu.GetSlideById(newSlideId);
                RefreshTheDisplay(currentMenuSlide);
            }
        }

        private void ReturnToPreviousMenu()
        {
            NewSlideId = currentMenuSlide.Id.Substring(0, currentMenuSlide.Id.Length - 2);
            currentMenuSlide = menu.GetSlideById(newSlideId);
            RefreshTheDisplay(currentMenuSlide);

        }

        private void RefreshTheDisplay(IMenuSlide menuSlide)
        {
            Console.Clear();

            for (int i = menuSlide.Options.Length - 1; i >= 0; i--)
            {
                int yCoordinate = 10 + menuSlide.Options.Length - i;

                if (i == menuSlide.SelectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string textLine = $"-->{menuSlide.Options[i]}<--";

                    Console.SetCursorPosition((Console.WindowWidth - textLine.Length) / 2, yCoordinate);
                    Console.WriteLine(textLine);

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    string textLine = menuSlide.Options[i];

                    Console.SetCursorPosition((Console.WindowWidth - textLine.Length) / 2, yCoordinate);
                    Console.WriteLine(textLine);
                }
            }
        }
    }
}
