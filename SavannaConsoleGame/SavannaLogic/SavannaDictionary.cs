using System.Collections.Generic;
using System.IO;
using SavannaConsoleGame.SavannaLogic.Animals;

namespace SavannaConsoleGame.SavannaLogic
{
    public class SavannaDictionary
    {
        public static Dictionary<char, System.Type> AnimalsAndLettersDictionary = new Dictionary<char, System.Type>();

        public static void SetDictionaryParameters()
        {
            string path = "";

            if (Directory.Exists(path))
            {
                string[] animals = Directory.GetFiles(path);
                foreach (string animal in animals)
                {
                    //System.Type type = animal.GetType();
                    //AnimalsAndLetters.Add(animal.Substring(0, 1), animal);
                }
            }
        }

        public static void SetDefautDictionaryParameters()
        {
            AnimalsAndLettersDictionary.Add('A', typeof(Antelope));
            AnimalsAndLettersDictionary.Add('L', typeof(Lion));
        }
    }
}
