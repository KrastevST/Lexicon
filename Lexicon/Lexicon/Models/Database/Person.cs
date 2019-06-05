namespace Lexicon.Models.Database
{
    using Lexicon.Models.Contracts;
    using System;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;

    [Serializable()]
    public class Person : IPerson, ISerializable
    {
        private string firstName;
        private string lastName;
        private int age;
        private string gender = "-";

        public Person()
        {
        }

        public IQuiz Quiz { get; set; }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-z]+$"))
                {
                    this.firstName = value;
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("FirstName", "You must enter a first name");
                }
                else
                {
                    throw new ArgumentException("First name can only contain letters");
                }
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-z]+$"))
                {
                    this.lastName = value;
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("LastName", "You must enter a last name");
                }
                else
                {
                    throw new ArgumentException("Last name can only contain letters");
                }
            }
        }
        public int Age
        {
            get => age;
            set
            {
                if (value < 1 || value > 150)
                {
                    throw new ArgumentException("Invalid age. Please enter an integer between 1 and 150");
                }

                this.age = value;
            }
        }
        public string Gender
        {
            get => gender;
            set
            {
                if (value.ToLower() == "male" || value.ToLower() == "female" || value == "-")
                {
                    this.gender = value;
                }
                else
                {
                    throw new ArgumentException(@"Invalid gender. Please type ""male"" or ""female"", if you do not wish to answer type ""-""");
                }
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", this.FirstName);
            info.AddValue("LastName", this.LastName);
            info.AddValue("Age", this.Age);
            info.AddValue("Gender", this.Gender);
            info.AddValue("Quiz", this.Quiz);
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            this.FirstName = (string)info.GetValue("FirstName", typeof(string));
            this.LastName = (string)info.GetValue("LastName", typeof(string));
            this.Age = (int)info.GetValue("Age", typeof(int));
            this.Gender = (string)info.GetValue("Gender", typeof(string));
            this.Quiz = (Quiz)info.GetValue("Quiz", typeof(Quiz));
        }
    }
}
