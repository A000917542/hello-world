namespace Vet.Domain.Interfaces;

using Vet.Domain.Entities;

public interface IAnimalService
{
    void AddAnimal(Animal animal);
    List<Animal> GetAllAnimals();
}