namespace Vet.Infrastructure;

using Vet.Domain.Entities;
using Vet.Domain.Interfaces;

public class AnimalRepository : IAnimalRepository
{
    private readonly List<Animal> _animals = new();

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public List<Animal> GetAllAnimals()
    {
        return _animals.ToList();
    }
}
