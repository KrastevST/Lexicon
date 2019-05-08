namespace Lexicon.Models.Contracts
{
    using System.Collections.Generic;

    public interface IQuiz
    {
        IDictionary<string, string> Data { get; set; }
    }
}
