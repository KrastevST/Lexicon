namespace Lexicon.Engine.DataCollection
{
    using System;
    using Lexicon.Engine.Contracts;
    using Lexicon.Models.Database;

    public class QuizMaster : IQuizMaster
    {
        private Person person;

        public void StartQuiz()
        {
            Console.Clear();
            CollectPersonalData();
            this.person.Quiz.Start();
            ListOfPeople.Add(this.person);
        }

        private void CollectPersonalData()
        {
            Console.Clear();
            Console.WriteLine("Please enter your first name:");
            string firstName = FormatName(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Please enter your last name:");
            string lastName = FormatName(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Please enter your age:");
            int age;
            int.TryParse(Console.ReadLine(), out age);
            Console.Clear();

            Console.WriteLine("Please enter your gender:");
            string gender = Console.ReadLine().ToLower();
            Console.Clear();

            try
            {
                this.person = new Person(firstName, lastName, age, gender);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                this.CollectPersonalData();
            }
        }

        private string FormatName(string name)
        {
            string result = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            return result;
        }
    }
}
