public enum DietType { Herbivore, Omnivore, Carnivore }

// Refactor to being abstract AFTER demoing
public abstract class Animal
{
    // This is demonstrating default values in constructors
    // Without this, we'd get a warning about Name being nullable
    // You can also make the type "string?"

    public Animal() { Name = "D.A.N."; }
    public Animal(string name)
    {
        Console.WriteLine("This is the Animal constructor");
        Name = name;
    }
    public string Name { get; set; } // = "D.A.N."; // You can also set a default value here
    public int NumberOfLegs { get; set; }
    public bool HasFur { get; set; }
    public DietType Diet { get; set; }

    public virtual void Move()
    {
        Console.WriteLine($"This {GetType().Name} moves.");
    }
}