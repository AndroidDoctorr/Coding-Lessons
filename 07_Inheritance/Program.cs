// Create the Person class first, and demo the constructor and the Name property
Person me = new Person("Andrew", "Torr", "123-456-7890", "email@fake.com");
me.SetFirstName("Rumplestiltskin");
Console.WriteLine(me.Name);

// Next, create the Customer class that inherits from Person and demo it similarly
// Explain that we're extending Person and adding properties
Customer customer = new Customer();

customer.SetFirstName("Customer");
customer.SetLastName("Person");
customer.IsPremium = true;

Console.WriteLine(customer.Name);
Console.WriteLine(customer.IsPremium);
// This is just for readability in the console
Console.WriteLine("\n\n\n");

// Create the Employee classes and demo
SalaryEmployee salaryEmployee = new SalaryEmployee();
salaryEmployee.Salary = 80000m;
Console.WriteLine(salaryEmployee is Employee);
Console.WriteLine(salaryEmployee is Person);
Console.WriteLine(salaryEmployee is Console);

HourlyEmployee hourlyEmployee = new HourlyEmployee();
hourlyEmployee.HourlyWage = 50.00m;
Console.WriteLine(hourlyEmployee is Employee);
Console.WriteLine(hourlyEmployee is Person);
Console.WriteLine(hourlyEmployee is List<string>);
Console.WriteLine("\n\n\n");

// Create the Animal class next, but DO NOT make it abstract at first

// Animal animal = new Animal();
// animal.Diet = DietType.Carnivore;
// animal.Move();

// Create a few inherited classes to demo, it doesn't have to be Mammal, Dog, and Cat

Mammal mammal = new Mammal("Dave");
mammal.Move();

Dog dog = new Dog();
dog.Move();
Console.WriteLine(dog.Name);
Console.WriteLine(dog.Diet);

// Make the Animal class and demo
// Make use of abstract/override
// Demo the base keyword

Bird bird = new Bird();
bird.Move();

Eagle eagle = new Eagle();
eagle.Move();

Lion lion = new Lion();
lion.MakeSound();
TabbyCat tabby = new TabbyCat();
tabby.MakeSound();