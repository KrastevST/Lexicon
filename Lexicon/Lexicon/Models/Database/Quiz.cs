namespace Lexicon.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Lexicon.Models.Contracts;
    using Lexicon.Utils;

    [Serializable()]
    public class Quiz : IQuiz, ISerializable
    {
        private readonly string defaultAnswer = "Not answered";
        private IReadOnlyCollection<string> questions =
            new List<string>
            {
                "What is your name?",
                "What is your quest?",
                "What is your favorite color?",
                "What is the capital of Assyria?",
                "What is the air-speed velocity of an unladen swallow?",
                "Did you like the quiz?",
                "Write something to the author?"
            };
        private IDictionary<string, string> questionnaire;

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
                    Console.Clear();

                    if (Questionnaire[question] == defaultAnswer)
                    {
                        Printer.PrintText(question, ConsoleColor.DarkYellow);
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
