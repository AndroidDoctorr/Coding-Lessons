public class Mammal : Animal
{
    public Mammal(string name) : base(name)
    {
        Console.WriteLine("This is the Mammal constructor");
        HasFur = true;
        NumberOfLegs = 4;
    }
}

public class Dog : Mammal
{
    public Dog() : base("Odie")
    {
        Console.WriteLine("This is the Dog constructor");
        Diet = DietType.Carnivore;
    }
}

public class Cat : Mammal
{
    public Cat() : base("Garfield")
    {
        Diet = DietType.Carnivore;
    }

    public double ClawLength { get; set; }

    public virtual void MakeSound()
    {
        Console.WriteLine("Meow.");
    }
}

public class Lion : Cat
{
    public override void MakeSound()
    {
        Console.WriteLine("Roar!");
    }
}

public class TabbyCat : Cat
{

}