namespace Lexicon.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Lexicon.Models.Contracts;

    [Serializable()]
    public class Quiz : IQuiz, ISerializable
    {
        // TODO arrange appropriately
        private IDictionary<string, string> data;
        private readonly string defaultAnswer = "Not answered";

        public Quiz()
        {
            this.Data = new Dictionary<string, string>();

            foreach (var question in Questions)
            {
                this.Data.Add(question, defaultAnswer);
            }
        }

        public IReadOnlyCollection<string> Questions =
            new List<string>
            {
                "What is your name?",
                "What is your quest?",
                "What is your favorite color",
                "What is your favorite movie?",
                "What is your favorite song?",
                "What is your dream destination?",
                "What would you grab if your house was on fire?",
                "Which three items would you take on a desert island?",
                "What is the best piece of advice someone has given you?",
                "Do you like this quiz?",
                "What do you think about the author?"
            };
        public IDictionary<string, string> Data { get => data; set => data = value; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Data", this.Data);
        }

        public Quiz(SerializationInfo info, StreamingContext context)
        {
            this.Data = (Dictionary<string, string>)info.GetValue("Data", typeof(Dictionary<string, string>));
        }

        public void Start()
        {
            while (this.Data.Values.Contains(defaultAnswer))
            {
                foreach (var question in Questions)
                {
                    // TODO Stylize text
                    // TODO add skip question functionality
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");

                    if (Data[question] == defaultAnswer)
                    {
                        Console.WriteLine(question);
                        Data[question] = Console.ReadLine();
                    }
                }
            }
        }
    }
}
