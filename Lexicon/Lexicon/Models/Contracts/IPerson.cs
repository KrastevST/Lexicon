namespace Lexicon.Models.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPerson
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        IQuiz Answers { get; set; }
    }
}
