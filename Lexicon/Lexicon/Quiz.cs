namespace Lexicon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quiz
    {
        private IDictionary<string, string> quizData;

        public Quiz()
        {
            this.quizData = new Dictionary<string, string>();

            this.quizData.Add("What is your name?", "");
            this.quizData.Add("What is your quest?", "");
            this.quizData.Add("What is your favorite color", "");
            this.quizData.Add("What is your favorite movie?", "");
            this.quizData.Add("What is your favorite song?", "");
            this.quizData.Add("What is your dream destination?", "");
            this.quizData.Add("What would you grab if your house was on fire?", "");
            this.quizData.Add("Which three items would you take on a desert island?", "");
            this.quizData.Add("What is the best piece of advice someone has given you?", "");
            this.quizData.Add("Do you like this quiz?", "");
            this.quizData.Add("What do you think about the author?", "");
        }
    }
}
