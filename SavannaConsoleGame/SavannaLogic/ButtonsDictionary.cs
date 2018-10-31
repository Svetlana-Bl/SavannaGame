using System.Collections.Generic;
using System.IO;
using SavannaConsoleGame.SavannaLogic.Animals;

namespace SavannaConsoleGame.SavannaLogic
{
    public class ButtonsDictionary
    {
        public static Dictionary<char, Animal> AnimalsAndLetters = new Dictionary<char, Animal>();

        public static void SetAnimalsButton()
        {
            string path = "C:\\Users\\svetlana.bluma\\source\\repos\\SavannaConsoleGame\\SavannaConsoleGame\\SavannaLogic\\Animals";

            if (Directory.Exists(path))
            {
                string[] animals = Directory.GetFiles(path);
                foreach (string animal in animals)
                {
                    //AnimalsAndLetters.Add(animal.Substring(0, 1), animal);
                }
            }
        }

        public static void SetDefautAnimalButton()
        {
            AnimalsAndLetters.Add('A', new Antelope());
            AnimalsAndLetters.Add('L', new Lion());
        }
    }
}