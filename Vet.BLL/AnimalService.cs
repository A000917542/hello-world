namespace Vet.BLL;

using Vet.DAL;
using Vet.Models;

public class AnimalService
{
    private readonly AnimalRepository _animals = new();

    public void AddAnimal(Animal animal)
    {
        _animals.AddAnimal(animal);
    }

    public List<Animal> GetAllAnimals()
    {
        return _animals.GetAllAnimals();
    }
}
