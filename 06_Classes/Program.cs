// This part needs to be at the top, but we'll actually do this last...
using _06_Classes;
ProgramUI ui = new ProgramUI();
ui.Start();


// START HERE: Create the Vehicle class first, then test it out here.
// Class declarations need to be beneath any top-level code


// We need to start by newing up an instance of our Vehicle class
Vehicle firstVehicle = new Vehicle();

// Now we can access the properties we declared inside the Vehicle class from the instance we declared
// We call the variable firstVehicle and use the dot operator to access the Make property
// As mentioned before, the = is the assignment operator and anything on the right gets assigned to the left (same as JavaScript)
firstVehicle.Make = "Honda";
// Now that the Make property is set, we can read from it
Console.WriteLine(firstVehicle.Make);

// Let's now set the other values as well
firstVehicle.Model = "Civic";
firstVehicle.Mileage = 30000;
firstVehicle.TypeOfVehicle = VehicleType.Car;

// Now we should have a Vehicle object with all properties assigned
// Go ahead and break point this if you have not already
// We can see that we can pull from this object now as well
string carDetails = $"{firstVehicle.Make} {firstVehicle.Model}";
Console.WriteLine(carDetails);


// Create the Person class next


// We'll need to start by instantiating a new instance of our Person class
// At this point you (or the students) may point out that there's no constructor
// Add one if you so desire, maybe one that takes in the FirstName, LastName, and DateOfBirth
Person firstPerson = new Person("Joshua", "Tucker", new DateTime(1995, 2, 4));

// Now we can call our FullName and Age properties and write them to the console
Console.WriteLine($"{firstPerson.FullName} is {firstPerson.Age} years old.");

// Now if we make a blank person without setting properties we can repeat the output but with the new information
Person blankPerson = new Person();
Console.WriteLine($"{blankPerson.FullName} is {blankPerson.Age} years old.");

// This is a good example of why we may not want to have a blank constructor for a class
// If our code expects that we set those properties we may not have the desired outcome
// Another option would be to go back to our FullName property and update it to fill in something if name is blank
// Go back to the Person class and update the FullName getter

// Next we'll add the Vehicle property to the Person class
// We can now show accessing a property from the property
firstPerson.Transport = new Vehicle();
firstPerson.Transport.Make = "Honda";
firstPerson.Transport.Model = "Civic";
firstPerson.Transport.Mileage = 30000;
firstPerson.Transport.TypeOfVehicle = VehicleType.Car;
Console.WriteLine(firstPerson.Transport.Mileage);

// We also can see the difference between a struct and class not being given a value
// Write out the Vehicle and DateTime properties that were not set in the blankPerson
Console.WriteLine("Unset class: " + blankPerson.Transport);
Console.WriteLine("Unset struct: " + blankPerson.DateOfBirth);


// Next, create the Greeter class


Greeter greeter = new Greeter();

// Here we can call our new SayHello() method from our Greeter class
greeter.SayHello();

// We also added those overloaded methods, so we can also pass in some values into the method
// The (string name) in the method is the defined PARAMETER
// the "Sara" is an example of an ARGUMENT given to the PARAMETER
greeter.SayHello("Sara");
greeter.SayHello("Kelly");

// Let's also call our GetRandomGreeting
greeter.GetRandomGreeting();
greeter.GetRandomGreeting();
greeter.GetRandomGreeting();
greeter.GetRandomGreeting();


// { CALCULATOR CLASS CHALLENGE }


// This code is getting rather long...
// Now that we have a way to separate code functionality into different domains using classes and methods,
// We can separate our code into different classes, and use methods to run certain parts of it at a time.
// We can also re-use code, or make our code more generic this way.

// Create a new class called ProgramUI in a new file called ProgramUI.cs
// The name of the file doesn't have to be the same a the name of the class in it.
// You can also have multiple classes defined in one file.



//  = = = = =  CLASS DECLARATIONS GO DOWN HERE  = = = = =



// Understanding classes can definitely be a difficult concept
// If we think back to working with the enum we made previously, we made our own type
// Let's do that again here with a VehicleType enum
public enum VehicleType { Car, Truck, Van, Motorcycle, Spaceship, Plane, Boat }

// We now have a type that we can use to help define vehicles, but what if we want to include more details?
// We can make our own class. Classes have their own properties and methods we can give them
// Let's start by creating our new class, Vehicle
public class Vehicle
{
    // Now we've seen that classes can have methods in them, but we also can give them properties
    // We've seen some of these before with an the Array.Length property
    // Properties are just variables but they exist in the entire class

    // 1 Access modifer => Just like with Methods
    // 2 Type => The type that the property can hold
    // 3 Name => The name of the property. Should be PascalCase just like Methods
    // 4 Getters and Setters => We'll talk about these more soon
    //1     //2    //3     //4
    public string Make { get; set; }
    public string Model { get; set; }
    public double Mileage { get; set; }

    // We can also use the enum VehicleType that we created above as a Property type
    public VehicleType TypeOfVehicle { get; set; }

    // Once we have a few different properties added create a couple instances of our Vehicle above this declaration
}

public class Person
{
    // For this new class, we want to know what makes a person a person
    // We'll set some general properties, feel free to have the students play around with this
    // That said, we'll want to introduce getters and setters here, so make sure you at least hit that

    // For this example we'll start with a first and last name
    public string FirstName { get; set; }

    // You can leave this as a simple property or build it out as a full property with a getter and setter
    // When making the FullName property you can come back and show this as a full property with the backing field

    // Here we have a "backing field" for the LastName property
    // We'll talk about Fields more in the near future, but basically they're variables for the entire class
    // Typically fields are not public
    private string _lastName;
    public string LastName
    {
        // We have our getter for the LastName property that returns the value stored in _lastName
        get { return _lastName; }
        // We have our setter that takes in whatever value is assigned to the property and stores it in _lastName
        set { _lastName = value; }
    }

    // Let's add one more property, DateOfBirth
    public DateTime DateOfBirth { get; set; }

    // As another example, we can come in and add a Vehicle property
    // This will be a good example of using a class just like any other type
    public Vehicle Transport { get; set; }

    // Once you start creating instances of your Person class you may want to come back and add Constructors
    // Add these to the top of the class
    public Person() { }
    public Person(string firstName, string lastName, DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    // So far these are just normal properties like we've seen so far
    // What we want to do now is add a FullName property so we can access both a Person's first and last name easily
    // Right now if we set the FirstName to Joshua and LastName to Tucker what will FullName be?
    // We don't want to have to update FullName every time we change FirstName or LastName
    // Let's actually go ahead and utilize the get method
    public string FullName
    {
        // Here we have a getter (get method) that is returning the value when the property is called
        // This creates a READONLY property without using the readonly keyword
        get
        {
            return $"{FirstName} {LastName}";
        }
    }

    // Now that we've seen the expanded properties we can add another, Age
    // Because we are using the DateOfBirth property to calculate it, we don't need a setter or backing field
    public int Age
    {
        get
        {
            // We're reusing our code from our Method CalculateAge we wrote in the Methods section
            // This allows us a dynamically updating Age after the DateOfBirth is set
            TimeSpan ageSpan = DateTime.Now - DateOfBirth;
            double totalAgeInYears = ageSpan.TotalDays / 365.25;
            int yearsOfAge = Convert.ToInt32(Math.Floor(totalAgeInYears));
            return yearsOfAge;
        }
    }
}

public class Greeter
{
    // Let's start by declaring our first custom method
    // The method structure:
    // 1 Access Modifier => Using public for this example, will cover these more later
    // 2 Return Type => We've seen this void before, means we are not returning anything
    // 3 Method Signature which is made up of the method name and parameters
    // 4 Body of code that gets executed
    //1    //2         //3
    public void SayHello(string name)
    {
        //4
        Console.WriteLine($"Hello, {name}!");
    }

    // We can also do something called overloading, where we have the same NAME but different set of PARAMETERS
    // Here we have a second SayHello method but this time it does not take any parameters in
    // Therefore the METHOD SIGNATURE is different, and as such works still
    public void SayHello()
    {
        Console.WriteLine("Hello!");
    }

    // Let's add a new method to get a random greeting

    // Here we've declared a FIELD called _random that is of the Random type
    // Think of this as just a variable inside the Greeter class, but any and all methods here can access it
    Random _random = new Random();
    // Now we can use this FIELD inside the 
    public void GetRandomGreeting()
    {
        string[] availableGreetings = new string[] { "Hello", "Howdy", "Hola", "Yo", "Greetings" };
        int randomNumber = _random.Next(0, availableGreetings.Length);
        string randomGreeting = availableGreetings.ElementAt(randomNumber); // availableGreetings[randomNumber]
        Console.WriteLine($"{randomGreeting}!");
    }
}

// Calculator Challenge Solution:
public class Calculator
{
    // Add
    public int Add(int numOne, int numTwo)
    {
        int sum = numOne + numTwo;
        return sum;
    }

    // Here we have another overloaded method
    public double Add(double numOne, double numTwo)
    {
        double sum = numOne + numTwo;
        return sum;
    }

    // Subtract

    // Multiply

    // Divide

    // Calculate Remainder

    // Let's make a more complicated method now
    // Here we have a method that calculates an age based on a given DateTime
    public int CalculateAge(DateTime birthdate)
    {
        TimeSpan ageSpan = DateTime.Now - birthdate;
        double totalAgeInYears = ageSpan.TotalDays / 365.25;
        // Here we can show off how we can use multiple methods to interact with each other
        // If the students need you can break this into different executing statements
        int years = Convert.ToInt32(Math.Floor(totalAgeInYears));
        return years;
    }
}