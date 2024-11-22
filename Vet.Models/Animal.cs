namespace Vet.Models;

public class Animal
{
    public string Name { get; set; }
    public string Owner { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }

    public Animal(string name, string owner, decimal weight, decimal height)
    {
        this.Name = name;
        this.Owner = owner;
        this.Weight = weight;
        this.Height = height;
    }

    public virtual string Greet()
    {
        return $"Hello {this.Name}!";
    }
}
