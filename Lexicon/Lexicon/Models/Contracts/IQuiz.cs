namespace Lexicon.Models.Contracts
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IQuiz
    {
        IDictionary<string, string> Questionnaire { get; set; }

        void Start();
    }
}
