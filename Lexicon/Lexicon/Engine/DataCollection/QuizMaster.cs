namespace Lexicon.Engine.DataCollection
{
    using Lexicon.Engine.Contracts;
    using Lexicon.Models.Contracts;
    using Lexicon.Models.Database;
    using System;

    public class QuizMaster : IQuizMaster
    {
        private IPerson person;

        public QuizMaster()
        {
            this.person = new Person();
        }

        public void CollectData()
        {
            Console.Clear();
            Console.WriteLine("Please enter your first name:");
            // TODO validate input for all properties
            this.person.FirstName = FormatName(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Please enter your last name:");
            // TODO validate input for all properties
            this.person.LastName = FormatName(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Please enter your age:");
            // TODO validate input for all properties
            int age;
            int.TryParse(Console.ReadLine(), out age);
            this.person.Age = age;
            Console.Clear();

            Console.WriteLine("Please enter your gender:");
            // TODO validate input for all properties
            this.person.Gender = Console.ReadLine().ToLower();
            Console.Clear();
        }

        public void StartQuiz()
        {
            Console.Clear();
            this.person.Quiz.Start();
        }

        private string FormatName(string name)
        {
            string result = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            return result;
        }
    }
}
