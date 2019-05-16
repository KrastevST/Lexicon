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
        private IDictionary<string, string> questionnaire;
        private readonly string defaultAnswer = "Not answered";
        private IReadOnlyCollection<string> questions =
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

        public Quiz()
        {
            this.Questionnaire = new Dictionary<string, string>();

            foreach (var question in questions)
            {
                this.Questionnaire.Add(question, defaultAnswer);
            }
        }

        public IDictionary<string, string> Questionnaire { get => this.questionnaire; set => this.questionnaire = value; }

        public void Start()
        {
            while (this.Questionnaire.Values.Contains(defaultAnswer))
            {
                foreach (var question in questions)
                {
                    // TODO Stylize text
                    // TODO add skip question functionality
                    Console.Clear();
                    // TODO swap newlines with cursor position
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");

                    if (Questionnaire[question] == defaultAnswer)
                    {
                        Console.WriteLine(question);
                        Questionnaire[question] = Console.ReadLine();
                    }
                }
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Questionnaire", this.Questionnaire);
        }

        public Quiz(SerializationInfo info, StreamingContext context)
        {
            this.Questionnaire = (Dictionary<string, string>)info.GetValue("Questionnaire", typeof(Dictionary<string, string>));
        }
    }
}
