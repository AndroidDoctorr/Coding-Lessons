// The students won't need this, since they should only have one Vehicle class
using _06_Classes.Methods;
// This one they will need
using _06_Classes.Classes;

// Don't forget to add the underscore at the beginning here!

public class ProgramUI
{
    // Once you have the Greeter, Calculator, Vehicle and Person classes set up, move
    // the classes to their own .cs files, in the Classes folder, and move the top-level code to this file.
    // Start by creating a Start() method as an entry point. We will call this in Program.cs later.
    // Remind the students that when we make structural changes to code like this, it's called "refactoring".

    public void Start()
    {
        // Start by cutting and pasting all the top-level code here.
        // Split this code into different methods:
        VehicleTest();
        PersonTest();
        GreeterTest();
        // (Optional)
        CalculatorTest();

        // Room Challenge
        RoomTest();

        // After the Room challenge, refactor the Vehicle class according to the model in the Members folder.
        // Add the code in the below VehicleTest method to test the new methods
    }
    public void VehicleTest()
    {
        // Paste Vehicle-related top-level code here
    }
    public void PersonTest()
    {
        // Paste Person-related top-level code here
    }
    public void GreeterTest()
    {
        // Paste Greeter-related top-level code here
    }
    public void CalculatorTest()
    {
        // Paste Calculator-related top-level code here
    }

    /*
        ===== ROOM CHALLENGE =====

        For this challenge we want to set up the basic part of the Room class for the students.
        We'll walk through setting the Max and Min values for the Length, Width, and Height.
        Afterwards we can give out this challenge to the students:


        Create a Room class that has three properties: one each for the length, width, and height.
        Create a method that calculates total square footage.

        We also would like to include some constants that the define a minimum and maximum length, width, and height.
        When setting the properties, make sure to compare the values to the min/max and only set them if the value is valid.

        Bonus:
        Create a method that calculates total lateral surface area.
        Only allow the properties to be set from inside the class itself.

        Throw an exception if the given value is outside the permitted range.
        Test the code like we did with the Vehicle tests.

        Give the students enough time to struggle on the problem, but make sure you leave enough time to walk through a solution with them

        When reviewing the challenge, remember to remind students that there is no one way to solve a problem with code.
        If they have a different solution, that may be fine as long as it works properly.
    */

    public void RoomTest()
    {
        // Now that we have our Room class all set up, we'll want to test our properties and methods
        // Note: when break pointing through properties with setters you may need to set the break point inside the setter
        Room room = new Room(8, 8, 10);

        Console.WriteLine(room.Length);
        Console.WriteLine(room.Width);
        Console.WriteLine(room.Height);

        // To test anything, we need to create a new Room object
        Room newRoom = new Room(10, 7, 10);

        // To actually test, we want to set up a few variables that we can compare
        double squareFootage = newRoom.CalculateSquareFootage();

        // To help visualize the output, we can write some strings
        // Just like we've seen before, this will show in the test's output
        Console.WriteLine($"Square footage: {squareFootage}");
    }

    public void VehicleMethodsTest()
    {
        // Let's declare a new Vehicle instance so we can start utilizing the methods we just made
        // The students will just use the existing Vehicle class
        VehicleRefactor transport = new VehicleRefactor();
        transport.IndicateLeft();

        // Let's also just write out so we know what happened
        Console.WriteLine("Indicating left");

        // Let's now write out to show which indicator is blinking
        Console.WriteLine($"Right Indicator: {transport.RightIndicator}");
        Console.WriteLine($"Left Indicator: {transport.LeftIndicator}");

        // If we want to use that code again, we might as well throw it into a method

        transport.IndicateRight();
        Console.WriteLine("Indicating right");
        CheckIndicators(transport);

        transport.TurnOnHazards();
        Console.WriteLine("Turning on Hazards");
        CheckIndicators(transport);
    }

    // Helper method for the above Test Method
    private void CheckIndicators(VehicleRefactor vehicle)
    {
        Console.WriteLine($"Right Indicator: {vehicle.RightIndicator}");
        Console.WriteLine($"Left Indicator: {vehicle.LeftIndicator}");
    }
}
