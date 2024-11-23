namespace Vet.UI;

using Vet.Domain.Entities;
using Vet.Domain.Interfaces;
using Vet.DomainServices;

public class ApplicationUI
{
    // private readonly IAnimalRepository _repository;
    private readonly IAnimalService _service;

    public ApplicationUI(IAnimalService service)
    {
        // _repository = repository;

        _service = service;
    }

    public void AddAnimal()
    {
        Console.WriteLine("Enter animal type (dog/cat):");
            string type = Console.ReadLine()?.ToLower() ?? string.Empty;
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter Owner:");
            string owner = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter age:");
            string? uiWeight = Console.ReadLine();
            Console.WriteLine("Enter age:");
            string? uiHeight = Console.ReadLine();

            int weight = int.Parse(uiWeight ?? "0");
            int height = int.Parse(uiHeight ?? "0");

            Animal? animal = type switch
            {
                "dog" => new Dog(name, owner, weight, height),
                "cat" => new Cat(name, owner, weight, height),
                _ => null
            };

            if (animal is not null)
            {
                _service.AddAnimal(animal);
                Console.WriteLine($"{animal.Name} added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid animal type.");
            }
            Console.Clear();
    }

    public void DisplayAnimals()
    {
        Console.Clear();
        var animals = _service.GetAllAnimals();
        foreach(var animal in animals)
        {
            Console.WriteLine(animal.Greet());
        }
        Console.Read();
    }

}
