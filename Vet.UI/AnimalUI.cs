using Vet.BLL;
using Vet.Models;

namespace Vet.UI;

public class AnimalUI
{
    private readonly AnimalService _animals = new();

    public void AddAnimal()
    {
        Console.WriteLine("What type of animal are you adding?");
        Console.WriteLine("\t1. Cat");
        Console.WriteLine("\t2. Dog");
        Console.Write("> ");
        var animal = Console.ReadKey();
        Console.WriteLine(string.Empty);
        Console.WriteLine("What is the animals name?");
        Console.Write("> ");
        var animalName = Console.ReadLine();
        Console.WriteLine("What is the owners name?");
        Console.Write("> ");
        var animalOwner = Console.ReadLine();
        Console.WriteLine("What is the animals weight (Kg)?");
        Console.Write("> ");
        var animalWeight = Console.ReadLine();
        Console.WriteLine("What is the animals height (cm)?");
        Console.Write("> ");
        var animalHeight = Console.ReadLine();

        var animalKg = decimal.Parse(animalWeight ?? "0");
        var animalCm = decimal.Parse(animalHeight ?? "0");

        Animal? newAnimal = null;

        switch(animal.KeyChar)
        {
            case '1':
                newAnimal = new Cat(animalName ?? string.Empty, animalOwner ?? string.Empty, animalKg, animalCm);
                break;
            case '2':
                newAnimal = new Dog(animalName ?? string.Empty, animalOwner ?? string.Empty, animalKg, animalCm);
                break;
        }

        if (newAnimal is not null)
        {
            _animals.AddAnimal(newAnimal);
        }
    }

    public void DisplayAnimals()
    {
        var animalList = _animals.GetAllAnimals();

        if (animalList.Count > 0)
        {
            Console.WriteLine("Todays Animals:");
            Console.WriteLine("--------------------------");
            foreach(var animal in animalList)
            {
                Console.WriteLine($"\u001b[31;1;4m{animal.Greet()}\u001b[0m");
            }
        }
        else
        {
            Console.WriteLine("No animals today.");
        }
    }
}
