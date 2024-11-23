namespace Vet.DomainServices;

using Vet.Domain.Entities;
using Vet.Domain.Interfaces;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _repository;

    public AnimalService(IAnimalRepository repository)
    {
        _repository = repository;
    }

    public void AddAnimal(Animal animal)
    {
        this._repository.AddAnimal(animal);
    }

    public List<Animal> GetAllAnimals()
    {
        return this._repository.GetAllAnimals();
    }
}
