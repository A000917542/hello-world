namespace Vet.Domain.Entities;

public class Cat : Animal
{
    public Cat(string name, string owner, decimal weight, decimal height)
        : base(name, owner, weight, height)
    { }

    public override string Greet()
    {
        return $"Meow, {this.Name}";
    }
}