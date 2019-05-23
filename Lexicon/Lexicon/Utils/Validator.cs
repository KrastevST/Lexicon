namespace Lexicon.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public static class Validator
    {
        public static bool ValidateWord(string word)
        {
            bool result = Regex.IsMatch(word, @"^[A-Za-z]+$");
            return result;
        }
    }
}
