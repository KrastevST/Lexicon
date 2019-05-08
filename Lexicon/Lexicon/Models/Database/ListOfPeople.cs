namespace Lexicon.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ListOfPeople
    {
        private static IList<Person> people;

        public static IList<Person> People { get => people; set => people = value; }
    }
}
