# Clean Architecture

## 1. Domain Layer
This layer contains the core business logic and entities.

```csharp
namespace AnimalHierarchy.Domain
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        protected Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract void MakeSound();
    }

    public class Dog : Animal
    {
        public Dog(string name, int age) : base(name, age) { }

        public override void MakeSound()
        {
            Console.WriteLine("Woof! Woof!");
        }
    }

    public class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age) { }

        public override void MakeSound()
        {
            Console.WriteLine("Meow! Meow!");
        }
    }
}
```

## 2. Application Layer
This layer contains the business logic and service interfaces.

```csharp
using System.Collections.Generic;
using AnimalHierarchy.Domain;

namespace AnimalHierarchy.Application
{
    public interface IAnimalRepository
    {
        void AddAnimal(Animal animal);
        List<Animal> GetAllAnimals();
    }

    public class AnimalService
    {
        private readonly IAnimalRepository _repository;

        public AnimalService(IAnimalRepository repository)
        {
            _repository = repository;
        }

        public void AddAnimal(Animal animal)
        {
            _repository.AddAnimal(animal);
        }

        public List<Animal> GetAllAnimals()
        {
            return _repository.GetAllAnimals();
        }
    }
}
```

## 3. Infrastructure Layer
This layer contains the implementation of the repository interfaces.

```csharp
using System.Collections.Generic;
using AnimalHierarchy.Application;
using AnimalHierarchy.Domain;

namespace AnimalHierarchy.Infrastructure
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly List<Animal> _animals = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }

        public List<Animal> GetAllAnimals()
        {
            return _animals;
        }
    }
}
```

## 4. Presentation Layer
This layer contains the user interface logic.

```csharp
using System;
using AnimalHierarchy.Application;
using AnimalHierarchy.Domain;
using AnimalHierarchy.Infrastructure;

namespace AnimalHierarchy.Presentation
{
    public class AnimalUI
    {
        private readonly AnimalService _service;

        public AnimalUI()
        {
            var repository = new AnimalRepository();
            _service = new AnimalService(repository);
        }

        public void AddAnimal()
        {
            Console.WriteLine("Enter animal type (dog/cat):");
            string type = Console.ReadLine().ToLower();
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());

            Animal animal = type switch
            {
                "dog" => new Dog(name, age),
                "cat" => new Cat(name, age),
                _ => null
            };

            if (animal != null)
            {
                _service.AddAnimal(animal);
                Console.WriteLine($"{animal.Name} added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid animal type.");
            }
        }

        public void DisplayAnimals()
        {
            var animals = _service.GetAllAnimals();
            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.Name} is {animal.Age} years old and says:");
                animal.MakeSound();
            }
        }
    }
}
```

## 5. Application Entry Point
This is the entry point of your application.

```csharp
using System;
using AnimalHierarchy.Presentation;

namespace AnimalHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new AnimalUI();
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Add Animal");
                Console.WriteLine("2. Display Animals");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ui.AddAnimal();
                        break;
                    case "2":
                        ui.DisplayAnimals();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
```
