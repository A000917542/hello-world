namespace Vet.Domain.Interfaces;

using Vet.Domain.Entities;

public interface IAnimalRepository
{
    void AddAnimal(Animal animal);
    List<Animal> GetAllAnimals();
}