using System;

namespace AbstractFactory
{
    public interface Animal
    {
        string speak();
    }

    public class Cat : Animal
    {
        public string speak()
        {
            return "Meow Meow Meow";
        }
    }

    public class Lion : Animal
    {
        public string speak()
        {
            return "Roar";
        }
    }

    public class Dog : Animal
    {
        public string speak()
        {
            return "Bark bark";
        }
    }

    public class Octopus : Animal
    {
        public string speak()
        {
            return "SQUAWCK";
        }
    }

    public class Shark : Animal
    {
        public string speak()
        {
            return "Cannot Speak";
        }
    }

    public abstract class AnimalFactory
    {
        public abstract Animal GetAnimal(string AnimalType);
        public static AnimalFactory CreateAnimalFactory(string FactoryType)
        {
            if (FactoryType.Equals("Sea"))
                return new SeaAnimalFactory();
            else
                return new LandAnimalFactory();
        }
    }

    public class LandAnimalFactory : AnimalFactory
    {
        public override Animal GetAnimal(string AnimalType)
        {
            if (AnimalType.Equals("Dog"))
            {
                return new Dog();
            }
            else if (AnimalType.Equals("Cat"))
            {
                return new Cat();
            }
            else if (AnimalType.Equals("Lion"))
            {
                return new Lion();
            }
            else
                return null;
        }
    }

    public class SeaAnimalFactory : AnimalFactory
    {
        public override Animal GetAnimal(string AnimalType)
        {
            if (AnimalType.Equals("Shark"))
            {
                return new Shark();
            }
            else if (AnimalType.Equals("Octopus"))
            {
                return new Octopus();
            }
            else
                return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Animal animal = null;
            //AnimalFactory animalFactory = null;
            //string speakSound = null;
            //// Create the Sea Factory object by passing the factory type as Sea
            //animalFactory = AnimalFactory.CreateAnimalFactory("Sea");
            //Console.WriteLine("Animal Factory type : " + animalFactory.GetType().Name);
            //Console.WriteLine();

            // Get Octopus Animal object by passing the animal type as Octopus
            //animal = animalFactory.GetAnimal("Octopus");
            //Console.WriteLine("Animal Type : " + animal.GetType().Name);
            //speakSound = animal.speak();
            //Console.WriteLine(animal.GetType().Name + " Speak : " + speakSound);
            //Console.WriteLine();


            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();
            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
            // Wait for user input
            Console.ReadKey();

        }
    }
}
