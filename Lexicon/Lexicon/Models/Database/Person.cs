namespace Lexicon.Models.Database
{
    using Lexicon.Models.Contracts;
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
            this.Quiz = new Quiz();
        }

        // TODO validate all properties
        public IQuiz Quiz { get; set; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }

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

        // TODO find best practice for positioning deserialization constructor
    }
}
