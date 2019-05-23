namespace Lexicon
{
    using Lexicon.Engine.Navigation;
    using Lexicon.Models.Database;
    using Lexicon.Utils;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    class Program
    {
        static void Main()
        {
            var nav = new Navigator();
            nav.Start();
        }
    }
}
