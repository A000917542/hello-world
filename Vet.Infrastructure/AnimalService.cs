using Vet.Domain.Interfaces;

namespace Vet.Infrastructure;

public class AnimalService : Vet.DomainServices.AnimalService
{   
    public AnimalService(IAnimalRepository repository)
        : base(repository)
    {}
}