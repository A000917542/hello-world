# 3-Tier Architecture

## 1. Base Class and Derived Classes

```csharp
using System;

namespace AnimalHierarchy
{
    public class Animal
    {
        private string name;
        private int age;

        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Some generic animal sound");
        }
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

## 2. Data Access Layer (DAL)
```csharp
using System.Collections.Generic;

namespace AnimalHierarchy.DAL
{
    public class AnimalRepository
    {
        private List<Animal> animals = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public List<Animal> GetAllAnimals()
        {
            return animals;
        }
    }
}
```

## 3. Business Logic Layer (BLL)
```csharp
using System.Collections.Generic;
using AnimalHierarchy.DAL;

namespace AnimalHierarchy.BLL
{
    public class AnimalService
    {
        private AnimalRepository repository = new AnimalRepository();

        public void AddAnimal(Animal animal)
        {
            repository.AddAnimal(animal);
        }

        public List<Animal> GetAllAnimals()
        {
            return repository.GetAllAnimals();
        }
    }
}
```

## 4. User Interface (UI)
```csharp
using System;
using AnimalHierarchy.BLL;

namespace AnimalHierarchy.UI
{
    public class AnimalUI
    {
        private AnimalService service = new AnimalService();

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
                service.AddAnimal(animal);
                Console.WriteLine($"{animal.Name} added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid animal type.");
            }
        }

        public void DisplayAnimals()
        {
            var animals = service.GetAllAnimals();
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
```csharp
using System;
using AnimalHierarchy.UI;

namespace AnimalHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalUI ui = new AnimalUI();
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
