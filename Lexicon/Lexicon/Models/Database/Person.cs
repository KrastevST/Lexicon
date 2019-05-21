namespace Lexicon.Models.Database
{
    using Lexicon.Models.Contracts;
    using Lexicon.Utils;
    using System;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable()]
    public class Person : IPerson, ISerializable
    {
        private string firstName;
        private string lastName;
        private int age;
        private string gender;

        public Person()
        {
        }

        public Person(string fName, string lName, int age, string gender)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Age = age;
            this.Gender = gender;

            this.Quiz = new Quiz();
        }

        // TODO validate all properties
        public IQuiz Quiz { get; set; }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (Validator.ValidateWord(value))
                {
                    this.firstName = value;
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("FirstName", "You must enter a first name");
                }
                else
                {
                    throw new ArgumentException("First name can only contain letters", "FirstName");
                }
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (Validator.ValidateWord(value))
                {
                    this.lastName = value;
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("LastName", "You must enter a last name");
                }
                else
                {
                    throw new ArgumentException("Last name can only contain letters", "LastName");
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
                    throw new ArgumentException("Invalid age. Please enter an integer between 1 and 150","Age");
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
                    throw new ArgumentException(@"Invalid gender. Please type ""male"" or ""female"", or type ""-"" if you do not wish to answer", "Gender");
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
