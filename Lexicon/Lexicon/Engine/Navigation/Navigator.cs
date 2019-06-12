namespace Lexicon.Engine.Navigation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
                else
                {
                    newSlideId = 1;
                }
            }
        }

        public void Start()
        {
            Formatter.FormatConsoleWindow();
            ListOfPeople.Load();
            UpdateListOfPeople();
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
                    case ConsoleKey.Escape:
                        ReturnToPreviousMenu();
                        break;
                    default:
                        RefreshMenuDisplay(currentMenuSlide);
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
            else if (this.NewSlideId == 120 || this.NewSlideId == 1220)
            {
                ReturnToPreviousMenu();
                ReturnToPreviousMenu();
            }
            else if (this.NewSlideId == 121)
            {
                ListOfPeople.Erase();
                UpdateListOfPeople();
            }
            else if (this.NewSlideId == 122 && ListOfPeople.People.Count == 0)
            {
                Printer.PrintQuestion("The list is empty. Press any key to return to the previous menu", ConsoleColor.DarkGreen);
                ConsoleKeyInfo info = Console.ReadKey();
                ReturnToPreviousMenu();
            }
            else if (this.NewSlideId > 1220)
            {
                int index = (this.NewSlideId % 10) - 1;
                var person = ListOfPeople.People[index];
                Console.Clear();
                Printer.PrintPersonalInfo(person);
                Console.WriteLine("     Press any key to return to previous menu");
                ConsoleKeyInfo info = Console.ReadKey();
                ReturnToPreviousMenu();
            }
            else
            {
                this.currentMenuSlide = menu.GetSlideById(this.NewSlideId);
                RefreshMenuDisplay(this.currentMenuSlide);
            }
        }

        private void ReturnToPreviousMenu()
        {
            // Id is the numeric pathway from main menu to the slide
            this.NewSlideId = this.NewSlideId / 10;
            this.currentMenuSlide = menu.GetSlideById(this.NewSlideId);
            RefreshMenuDisplay(this.currentMenuSlide);

        }

        private void RefreshMenuDisplay(IMenuSlide menuSlide)
        {
            Console.Clear();

            for (int i = menuSlide.Options.Count - 1; i >= 0; i--)
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
                int yCoordinate = 10 + menuSlide.Options.Count - i;
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
                return;
            }

            qMaster.CollectQuizData();
            qMaster.SaveAllData();
            ListOfPeople.Save();
            UpdateListOfPeople();
            Printer.PrintQuestion("Thank you for taking the quiz! Press any key to return to Main Menu", ConsoleColor.DarkGreen);
            ConsoleKeyInfo info = Console.ReadKey();
            ReturnToPreviousMenu();
            ReturnToPreviousMenu();
        }

        private void UpdateListOfPeople()
        {
            var listOfPeopleSlide = this.menu.Slides.FirstOrDefault(x => x.Id == 122);
            this.menu.Slides.Remove(listOfPeopleSlide);

            if (ListOfPeople.People.Count != 0)
            {
                List<string> peopleNames = ListOfPeople.People.Select(x => $"{x.FirstName} {x.LastName}").ToList();
                peopleNames.Insert(0, "Return");

                this.menu.Slides.Add(new MenuSlide(122, peopleNames));
            }
        }
    }
}
