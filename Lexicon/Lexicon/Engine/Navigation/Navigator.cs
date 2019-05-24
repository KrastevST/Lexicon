namespace Lexicon.Engine.Navigation
{
    using System;
    using Lexicon.Engine.Contracts;
    using Lexicon.Engine.DataCollection;
    using Lexicon.Exceptions;
    using Lexicon.Models.Contracts;
    using Lexicon.Models.Database;
    using Lexicon.Models.Menus;
    using Lexicon.Utils;

    public class Navigator : INavigator
    {
        private IMenu menu;
        private IMenuSlide currentMenuSlide;
        private int newSlideId;

        public Navigator()
        {
            this.menu = new Menu();
            this.newSlideId = 1;
            this.currentMenuSlide = this.menu.GetSlideById(this.NewSlideId);
        }

        private int NewSlideId
        {
            get => this.newSlideId;
            set
            {
                if (value >= 1)
                {
                    newSlideId = value;
                }
            }
        }

        public void Start()
        {
            Formatter.FormatConsoleWindow();
            ListOfPeople.Load();
            RefreshMenuDisplay(this.currentMenuSlide);

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
            RefreshMenuDisplay(currentMenuSlide);
        }

        private void SwitchDownwards()
        {
            this.currentMenuSlide.SelectedOption--;
            RefreshMenuDisplay(this.currentMenuSlide);
        }

        private void EnterSelectedOption()
        {
            // Id is the numeric pathway from main menu to the slide
            this.NewSlideId = this.currentMenuSlide.Id * 10 + this.currentMenuSlide.SelectedOption;


            if (this.NewSlideId == 10)
            {
                ListOfPeople.Save();
                Environment.Exit(0);
            }
            else if (this.NewSlideId == 11)
            {
                this.TakeTheQuiz();
            }
            else
            {
                this.currentMenuSlide = menu.GetSlideById(this.NewSlideId);
                RefreshMenuDisplay(this.currentMenuSlide);
            }
        }

        private void ReturnToPreviousMenu()
        {
            this.NewSlideId = this.NewSlideId / 10; 
            this.currentMenuSlide = menu.GetSlideById(this.NewSlideId);
            RefreshMenuDisplay(this.currentMenuSlide);

        }

        private void RefreshMenuDisplay(IMenuSlide menuSlide)
        {
            Console.Clear();

            for (int i = menuSlide.Options.Length - 1; i >= 0; i--)
            {
                string textLine;
                ConsoleColor color;

                if (i == menuSlide.SelectedOption)
                {
                    textLine = $"-->{menuSlide.Options[i]}<--";
                    color = ConsoleColor.DarkBlue;
                }
                else
                {
                    textLine = menuSlide.Options[i];
                    color = ConsoleColor.DarkGreen;
                }

                int xCoordinate = (Console.WindowWidth - textLine.Length) / 2;
                int yCoordinate = 10 + menuSlide.Options.Length - i;
                Printer.PrintMenuOption(textLine, xCoordinate, yCoordinate, color);
            }
        }

        private void TakeTheQuiz()
        {
            var qMaster = new QuizMaster();
            try
            {
                qMaster.CollectPersonalData();
            }
            catch (MethodTerminationException)
            {
                ReturnToPreviousMenu();
            }
        }
    }
}
