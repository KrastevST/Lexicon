namespace Lexicon.Engine.DataCollection
{
    using System;
    using Lexicon.Engine.Contracts;
    using Lexicon.Engine.Navigation;
    using Lexicon.Exceptions;
    using Lexicon.Models.Database;
    using Lexicon.Utils;

    public class QuizMaster : IQuizMaster
    {
        private Person person;

        public QuizMaster()
        {
            this.person = new Person();
        }

        public void CollectPersonalData()
        {
            this.CollectFirstName();
            this.CollectLastName();
            this.CollectAge();
            this.CollectGender();
        }

        public void CollectQuizData()
        {
            this.person.Quiz = new Quiz();
            this.person.Quiz.Start();
        }

        public void SaveAllData()
        {
            ListOfPeople.Add(this.person);
        }

        private void CollectFirstName()
        {
            try
            {
                Printer.PrintText("Please enter your first name:", ConsoleColor.DarkYellow);
                this.person.FirstName = Console.ReadLine();
            }
            catch (ArgumentNullException ex)
            {
                Handle(ex, CollectFirstName);
            }
            catch (ArgumentException ex)
            {
                Handle(ex, CollectFirstName);
            }
        }

        private void CollectLastName()
        {
            try
            {
                Printer.PrintText("Please enter your last name:", ConsoleColor.DarkYellow);
                this.person.LastName = Console.ReadLine();
            }
            catch (ArgumentNullException ex)
            {
                Handle(ex, CollectLastName);
            }
            catch (ArgumentException ex)
            {
                Handle(ex, CollectLastName);
            }

        }

        private void CollectAge()
        {
            try
            {
                Printer.PrintText("Please enter your age:", ConsoleColor.DarkYellow);
                int age;
                int.TryParse(Console.ReadLine(), out age);
                this.person.Age = age;
            }
            catch (ArgumentException ex)
            {
                Handle(ex, CollectAge);
            }
        }

        private void CollectGender()
        {
            try
            {
                Printer.PrintText("Please enter your gender:", ConsoleColor.DarkYellow);
                this.person.Gender = Console.ReadLine().ToLower();
            }
            catch (ArgumentException ex)
            {
                Handle(ex, CollectGender);
            }
        }

        private void Handle(Exception ex, Action currentMethod)
        {
            var footNav = new FooterNavigator();

            Printer.PrintError(ex.Message);
            footNav.Display();

            bool repeat = footNav.IsRepeating();
            if (repeat)
            {
                currentMethod();
            }
            else
            {
                throw new MethodTerminationException();
            }
        }
    }
}
