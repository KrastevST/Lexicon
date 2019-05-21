namespace Lexicon.Engine.DataCollection
{
    using System;
    using Lexicon.Engine.Contracts;
    using Lexicon.Models.Database;
    using Lexicon.Utils;

    public class QuizMaster : IQuizMaster
    {
        private Person person;

        public void CollectPersonalData()
        {
            this.person = new Person();

            // TODO finish here first
            Printer.PrintQuestion("Please enter your first name:", ConsoleColor.DarkYellow);
            this.person.FirstName = Console.ReadLine();

            Printer.PrintQuestion("Please enter your last name:", ConsoleColor.DarkYellow);
            this.person.LastName = Console.ReadLine();

            Printer.PrintQuestion("Please enter your age:", ConsoleColor.DarkYellow);
            int age;
            int.TryParse(Console.ReadLine(), out age);
            this.person.Age = age;

            Printer.PrintQuestion("Please enter your gender:", ConsoleColor.DarkYellow);
            this.person.Gender = Console.ReadLine().ToLower();

            
        }
    }
}
