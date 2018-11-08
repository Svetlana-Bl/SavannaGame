using System;
using System.Collections.Generic;
using System.Reflection;
using SavannaConsoleGame.SavannaLogic.Animals;

namespace SavannaConsoleGame.SavannaLogic
{
    public class SavannaDictionary
    {
        public static Dictionary<char, System.Type> AnimalsAndLettersDictionary = new Dictionary<char, System.Type>();

        public static void SetDictionaryParameters()
        {
            var DLL = Assembly.LoadFile(@"C:\Users\svetlana.bluma\source\repos\SavannaConsoleGame\SavannaConsoleGame\SavannaLogic\LoadedAnimals");

            foreach (Type type in DLL.GetExportedTypes())
            {
                string nameOfType = Convert.ToString(type);
                AnimalsAndLettersDictionary.Add(Convert.ToChar(nameOfType.Substring(0, 1)), type);
            }
        }

        public static void SetDefautDictionaryParameters()
        {
            AnimalsAndLettersDictionary.Add('A', typeof(Antelope));
            AnimalsAndLettersDictionary.Add('L', typeof(Lion));
        }
    }
}