using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        
        public class Animals
        {
            
            public enum Diet
            {

                carnivore,
                herbivore,
                omnivore

            }

            private string _speciesName;
            private int _age;
            private bool _isMammal;
            private Diet _diet;

            public string speciesName
            {
                get { return _speciesName; }
                set { _speciesName = value; }
            }

            public int age
            {
                get { return _age; }
                set { _age = value; }
            }

            public bool isMammal
            {
                get { return _isMammal; }
                set { _isMammal = value; }
            }
            public Diet diet
            {

                get { return _diet; }
                set { _diet = value; }

            }
            
        }

        static void Main(string[] args)
        {

            List<Animals> animals_full = AddObjects();

            DisplayObjects(animals_full);

            saveAnimals(animals_full);

        }
        static List<Animals> AddObjects()
        {
            bool loop = true;
            
            List<Animals> animals = new List<Animals>();

            Console.WriteLine();
            Console.WriteLine("\t\tAdd Animals");
            Console.WriteLine();

            do
            {
       
                AddAnimals(animals);

                Console.WriteLine("\t\tWould you like to add another animal? [yes/no]");
                string userInput = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (userInput == "no")
                {
   
                    Console.WriteLine("Press any key to display animals.");
                    Console.ReadLine();
                    Console.WriteLine();
                    loop = false;

                }
                else if (userInput == "yes")
                {

                    loop = true;

                }
                else
                {

                    Console.WriteLine("Not a valid response, try again.");
                    Console.ReadLine();

                }

            } while (loop == true);

            Console.WriteLine();

            return animals;    
        }

        private static void AddAnimals(List<Animals> animals)
        {

            Animals animal = new Animals();

            //species

            Console.WriteLine("Species: ");
            animal.speciesName = Console.ReadLine().ToLower();
            Console.WriteLine();

            //age

            Console.WriteLine("Age (in years): ");

            bool validAge = false;

            do
            {

                if (int.TryParse(Console.ReadLine().ToLower(), out int age))
                {

                    animal.age = age;
                    validAge = true;
                    Console.WriteLine();

                }
                else
                {

                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid age.");
                    Console.WriteLine();

                }
            } while (!validAge);

            //mammal

            Console.WriteLine("Is it a Mammal [true/false]: ");

            bool validBool = false;

            do
            {

                if (bool.TryParse(Console.ReadLine().ToLower(), out bool isMammal))
                {

                    animal.isMammal = isMammal;
                    validBool = true;
                    Console.WriteLine();

                }
                else
                {

                    Console.WriteLine();
                    Console.WriteLine("Input is not valid. Please try again.");
                    Console.WriteLine();

                }
            } while (!validBool);

            //diet

            Console.WriteLine("Diet [carnivore/herbivore/omnivore]: ");
            
            bool validDiet = false;

            do
            {            

                if (Enum.TryParse(Console.ReadLine().ToLower(), out Animals.Diet diet))
                {

                    animal.diet = diet;
                    validDiet = true;
                    Console.WriteLine();

                }
                else
                {

                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid diet.");
                    Console.WriteLine();

                }
            } while (!validDiet);

            animals.Add(animal);

        }

        private static void DisplayObjects(List<Animals> full_animals)
        {
            //headers

            Console.WriteLine(
                "Species".PadLeft(15) +
                "Age".PadLeft(12) +
                "Mammal:".PadLeft(15) +
                "Diet:".PadLeft(14)
                 );

            Console.WriteLine(
                "-------".PadLeft(15) +
                "---".PadLeft(12) +
                "------".PadLeft(15) +
                "----".PadLeft(14)
                );

            foreach (Animals animal in full_animals)
            {

                Console.WriteLine();
                Console.WriteLine(
                    animal.speciesName.PadLeft(15) +
                    animal.age.ToString().PadLeft(12) +
                    animal.isMammal.ToString().PadLeft(15) +
                    animal.diet.ToString().PadLeft(14)
                    );

            }

            Console.WriteLine();

            Console.WriteLine("\tPress any key to end...");
            Console.ReadLine();         

        }
        private static void saveAnimals(List<Animals> full_animals)
        {

            string dataPath = @"Data\animals.txt";
            string animalString;

            foreach (Animals animal in full_animals)
            {

                animalString = animal.speciesName + "," + animal.age + "," + animal.isMammal + "," + animal.diet + Environment.NewLine;
                File.AppendAllText(dataPath, animalString);

            }

        }
    }

        

        

    
}
