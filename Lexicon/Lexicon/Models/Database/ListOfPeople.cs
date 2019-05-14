namespace Lexicon.Models.Database
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public static class ListOfPeople
    {
        private static IList<Person> people;
        private static readonly string saveFile = "ListOfPeople.dat";

        public static IList<Person> People { get => people; set => people = value; }

        public static void Save()
        {
            Stream stream = File.Open(saveFile, FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, People);
            stream.Close();
        }

        public static void Load()
        {
            if (File.Exists(saveFile))
            {
                Stream stream = File.Open(saveFile, FileMode.Open);


                BinaryFormatter bf = new BinaryFormatter();

                People = (List<Person>)bf.Deserialize(stream);
                stream.Close();
            }
            else
            {
                People = new List<Person>();
            }
        }

        public static void Erase()
        {
            if (File.Exists(saveFile))
            {
                File.Delete(saveFile);
            }
        }
    }
}
