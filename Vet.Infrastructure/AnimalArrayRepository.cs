namespace Vet.Infrastructure;

using Vet.Domain.Entities;
using Vet.Domain.Interfaces;

public class AnimalArrayRepository : IAnimalRepository
{
    private readonly Animal[] _animals = new Animal[10];
    private int index = 0;

    public void AddAnimal(Animal animal)
    {
        _animals[index % _animals.Length] = animal;
        index++;
    }

    public List<Animal> GetAllAnimals()
    {
        return _animals.ToList();
    }
}
