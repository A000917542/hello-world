namespace Vet.DAL;

using Vet.Models;

public class AnimalRepository
{
    private readonly List<Animal> _animals = new();

    public AnimalRepository()
    {
        this.Seed();
    }

    // Temporary for testing
    public void Seed()
    {
        _animals.Add(new Animal("Max", "Max", 1.1M, 2.4M));
        _animals.Add(new Cat("Marty", "Max", 2.6M, 3.4M));
        _animals.Add(new Dog("Bob", "Max", 1.7M, 2.5M));
    }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public List<Animal> GetAllAnimals()
    {
        return _animals;
    }
}
