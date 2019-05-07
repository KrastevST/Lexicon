namespace Lexicon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private string gender;


        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public Person(string fName, string lName, int age, string gender)
        {

        }

        public Quiz CompletedQuiz { get;}
    }
}
