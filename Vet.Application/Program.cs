using System.Runtime.CompilerServices;
using Vet.UI;

var _animalUI = new AnimalUI();

while (true)
{
    Console.WriteLine("Hello, Welcome to VetApp!");
    Console.WriteLine(string.Empty);
    Console.WriteLine("\t1. Add an Animal\b");
    Console.WriteLine("\t2. Display All Animals\b");
    Console.WriteLine("\t3. Exit\b");
    Console.WriteLine(string.Empty);

    Console.Write("> ");
    var selection = Console.ReadKey();

    switch(selection.KeyChar)
    {
        case '1':
            _animalUI.AddAnimal();
            break;
        case '2':
            _animalUI.DisplayAnimals();
            break;
        case '3':
            // return;
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Please select a valid option.");
            break;
    }
}