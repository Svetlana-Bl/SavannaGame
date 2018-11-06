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
            int rowCoordinate = -1, columnCoordinate = -1;
            List<char> animals = SetPredatorOrPreyList();
            Animal foundAnimal=null;
            int i = 0;
            while (animals.Count != i)
            {
                if (rowCoordinate != -1 && columnCoordinate != -1)
                    break;
                foundAnimal = UpdateVision(animals[i], rowCoordinate, columnCoordinate);
                rowCoordinate = foundAnimal.LocationX;
                columnCoordinate = foundAnimal.LocationY;
                i++;
            }

            if (rowCoordinate == -1 && columnCoordinate == -1)
            {
                Move();
            }
            else
            {
                if(Health!=0)
                    SpecialAction(rowCoordinate, columnCoordinate);
            }
        }

        public Animal UpdateVision(char animalButton, int x, int y)
        {
            Type animalType = SavannaDictionary.AnimalsAndLettersDictionary[animalButton];
            Animal animal = (Animal)Activator.CreateInstance(animalType);
            animal.LocationX = -1;
            animal.LocationY = -1;
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
                        animal.LocationX = rowCoordinate;
                        animal.LocationY = columnCoordinate;
                        break;
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
