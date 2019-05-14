namespace Lexicon.Engine.DataCollection
{
    using Lexicon.Engine.Contracts;
    using Lexicon.Models.Contracts;
    using Lexicon.Models.Database;

    public class QuizMaster : IQuizMaster
    {
        private IPerson person;

        public QuizMaster()
        {
            this.person = new Person();
        }

        public void CollectData()
        {
            // TODO ask the 4 property questions
        }

        public void StartQuiz()
        {
            // TODO loop the quiz
        }
    }
}
