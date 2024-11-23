using Vet.Infrastructure;
using Vet.UI;

var repository = new AnimalArrayRepository();
var animalService = new AnimalService(repository);

repository.AddAnimal(new Vet.Domain.Entities.Dog("Woofy","Brent", 2.4M, 1.2M));
repository.AddAnimal(new Vet.Domain.Entities.Cat("Meowy","Brent", 1.6M, 4.3M));

var ui = new ApplicationUI(animalService);

bool running = true;

Console.Clear();

do
{
    Console.WriteLine("Vetrinary Application");
    Console.WriteLine("\t1. Add Animal");
    Console.WriteLine("\t2. Display All Animals");
    Console.WriteLine("\t3. Exit");
    Console.Write("Choose an option: > ");
    var selection = Console.ReadKey();
    Console.WriteLine(string.Empty);

    switch(selection.KeyChar)
    {
        case '1':
            ui.AddAnimal();
            break;
        case '2':
            ui.DisplayAnimals();
            break;
        case '3':
            running = false;
            break;
        default:
            Console.WriteLine("Please select a valid option.");
            break;
    }
} while(running);