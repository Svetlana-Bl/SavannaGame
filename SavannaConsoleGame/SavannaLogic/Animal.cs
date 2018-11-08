using System;
using System.Collections.Generic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public abstract class Animal
    {
        public char ButtonSymbol { get; set; }
        public bool LiveState { get; set; }
        public bool Predator { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public List<Progeny> Progeny = new List<Progeny>();
        public List<char> Enemies { get; set; }
        public List<char> Prey { get; set; }

        public static Random random = new Random();

        private double _health;
        public double Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value <= 0) Die();
                _health = value;
            }
        }

        public virtual void Behavior()
        {
            List<char> animals = SetPredatorOrPreyList();
            Animal foundAnimal = null;
            int i = 0;

            while (animals.Count != i)
            {
                foundAnimal = UpdateVision(animals[i], false);
                i++;
                if (foundAnimal.LocationX != 0 && foundAnimal.LocationY != 0)
                    break;
            }

            if (foundAnimal.LocationX == 0 && foundAnimal.LocationY == 0)
            {
                foundAnimal = UpdateVision(ButtonSymbol, true);
                if (foundAnimal.LocationX != 0 && foundAnimal.LocationY != 0 && ButtonSymbol == 'A')
                {
                    SetPotentialPartner(foundAnimal);
                    Move();
                    CheckPartnerStillNear(foundAnimal);
                }
                else
                {
                    Move();
                }

            }
            else
            {
                if (Health != 0)
                    SpecialAction(foundAnimal.LocationX, foundAnimal.LocationY);
            }
        }

        public void SetPotentialPartner(Animal potencialPartner)
        {
            bool noSuchParentYet = true;
            Progeny progeny = new Progeny();
            int i = 0;

            if (Progeny.Count == 0)
            {
                Progeny.Add(new Progeny());
                progeny = Progeny[0];
                progeny.IterationCount = 0;
                progeny.parent = potencialPartner;
                progeny.NearOrNot = true;
                Progeny[0] = progeny;
            }

            while (i < Progeny.Count)
            {
                progeny = Progeny[i];
                if (object.ReferenceEquals(potencialPartner, Progeny[i].parent))
                {
                    noSuchParentYet = false;
                    progeny.IterationCount++;
                    Progeny[i] = progeny;
                }

                if (Progeny.Count - 1 == i && noSuchParentYet == true)
                {
                    Progeny.Add(new Progeny());
                    progeny.IterationCount = 1;
                    progeny.parent = potencialPartner;
                    progeny.NearOrNot = true;
                    Progeny[i + 1] = progeny;
                    Console.WriteLine("iter {0}", progeny.IterationCount);
                }

                if (Progeny[i].IterationCount == 3)
                {
                    Birth();
                    progeny.IterationCount = 0;
                    progeny.NearOrNot = true;
                    Progeny[i] = progeny;
                }
                i++;
            }
        }

        public void CheckPartnerStillNear(Animal partner)
        {
            Animal animal;
            Progeny progeny = new Progeny();
            if (Progeny.Count == 0)
            {
                for (int i = 0; i < Progeny.Count; i++)
                {
                    progeny = Progeny[i];
                    progeny.NearOrNot = false;
                    animal = progeny.parent;

                    if (object.ReferenceEquals(partner, animal))
                    {
                        progeny.NearOrNot = true;
                    }
                    Progeny[i] = progeny;
                }
                for (int i = 0; i < Progeny.Count; i++)
                {
                    progeny = Progeny[i];
                    if (progeny.NearOrNot == false)
                    {
                        Progeny.RemoveAt(i);
                        i--;
                    }
                }
            }
        }


        public void Birth()
        {
            AnimalCreationOnTheField.SetNewAnimalPosition(ButtonSymbol);
        }

        public Animal UpdateVision(char animalButton, bool sameAnimal)
        {
            Type animalType = SavannaDictionary.AnimalsAndLettersDictionary[animalButton];
            Animal animal = (Animal)Activator.CreateInstance(animalType);
            VisionRange animalVisionRange = new VisionRange();

            animalVisionRange = VisionRangeFocus(animalVisionRange);

            for (int rowCoordinate = animalVisionRange.startRowCoordinate; rowCoordinate < animalVisionRange.endRowCoordinate; rowCoordinate++)
            {
                for (int columnCoordinate = animalVisionRange.startColumnCoordinate; columnCoordinate < animalVisionRange.endColumnCoordinate; columnCoordinate++)
                {
                    if (rowCoordinate == LocationX && columnCoordinate == LocationY)
                        continue;
                    if (GameField.Field[rowCoordinate, columnCoordinate] == animalButton)
                    {
                        for (int i = 0; i < SavannaAnimals.Animals.Count; i++)
                        {
                            if (SavannaAnimals.Animals[i].LocationX == rowCoordinate && SavannaAnimals.Animals[i].LocationY == columnCoordinate)
                            {
                                animal = SavannaAnimals.Animals[i];
                            }
                        }

                        if (sameAnimal == false)
                        {
                            break;
                        }
                        else
                        {
                            CheckPartnerStillNear(animal);
                        }
                    }
                }
            }
            return animal;
        }

        public void Move()
        {
            bool approach = false;
            VisionRange animalVisionRange = new VisionRange();

            animalVisionRange = VisionRangeFocus(animalVisionRange);

            while (approach != true)
            {
                int randomX, randomY;
                randomX = random.Next(animalVisionRange.startRowCoordinate, animalVisionRange.endRowCoordinate);
                randomY = random.Next(animalVisionRange.startColumnCoordinate, animalVisionRange.endColumnCoordinate);

                if (LocationX != randomX && LocationY != randomY)
                {

                    LocationX = randomX;
                    LocationY = randomY;

                    if (GameField.NextStepField[LocationX, LocationY] == '_')
                    {
                        GameField.NextStepField[LocationX, LocationY] = ButtonSymbol;
                        approach = true;
                    }
                }
            }
        }

        public virtual void SpecialAction(int x, int y)
        {
            Move();
        }

        public virtual void DecreaseHealth()
        {
            Health -= 0.5;
        }

        public virtual void IncreaseHealth()
        {
            Health++;
        }

        public void Die()
        {
            LiveState = false;
        }

        private List<char> SetPredatorOrPreyList()
        {
            List<char> PredatorOrPreyList = new List<char>();
            if (Predator == true)
            {
                if (Prey.Count != 0)
                    PredatorOrPreyList = Prey;
            }
            else
            {
                if (Enemies.Count != 0)
                    PredatorOrPreyList = Enemies;
            }
            return PredatorOrPreyList;
        }

        internal VisionRange VisionRangeFocus(VisionRange animalVisionRange)
        {
            animalVisionRange.startRowCoordinate = LocationX - 1;
            animalVisionRange.endRowCoordinate = LocationX + 2;
            animalVisionRange.startColumnCoordinate = LocationY - 1;
            animalVisionRange.endColumnCoordinate = LocationY + 2;

            if (LocationX == 0) animalVisionRange.startRowCoordinate = LocationX;
            if (LocationX == GameField.FieldLength - 1) animalVisionRange.endRowCoordinate = GameField.FieldLength;
            if (LocationY == 0) animalVisionRange.startColumnCoordinate = LocationY;
            if (LocationY == GameField.FieldWidth - 1) animalVisionRange.endColumnCoordinate = GameField.FieldWidth;
            return animalVisionRange;
        }
    }
}
