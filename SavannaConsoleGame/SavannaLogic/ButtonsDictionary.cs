using System.Collections.Generic;
using System.IO;
using SavannaConsoleGame.SavannaLogic.Animals;

namespace SavannaConsoleGame.SavannaLogic
{
    public class ButtonsDictionary
    {
        public static Dictionary<char, System.Type> AnimalsAndLettersDictionary = new Dictionary<char, System.Type>();

        public static void SetAnimalsButton()
        {
            string path = "C:\\Users\\svetlana.bluma\\source\\repos\\SavannaConsoleGame\\SavannaConsoleGame\\SavannaLogic\\Animals";

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

        public static void SetDefautAnimalButton()
        {
            AnimalsAndLettersDictionary.Add('A', typeof(Antelope));
            AnimalsAndLettersDictionary.Add('L', typeof(Lion));
        }
    }
}