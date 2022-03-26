using _06_Classes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Classes.Methods
{
    public class VehicleRefactor
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Mileage { get; set; }

        public VehicleType TypeOfVehicle { get; set; }

        // Now that we've seen some other method examples, let's go ahead and build out a few methods for our Vehicle Class
        // Think of what Vehicles as a concept can do
        // Turn on, turn off, drive, stop, indicate, etc

        // Let's start with turn on and turn off, but first we will want to add a new property to indicate if the vehicle is running
        // Here we have a boolean property (true or false) that will allow us to see and change if the vehicle is currently running

        // We're going to do something different, and make this a private set.
        // Like our other methods we've created so far, get and set also can have access modifiers
        // This means that the IsRunning property can only be changed (or set) from inside the Vehicle class
        // This allows us to control the flow, meaning that you can only change this value through the proper process
        public bool IsRunning { get; private set; }

        // Now let's make our method to change this property
        public void TurnOn()
        {
            // We can just go ahead and set our new property
            IsRunning = true;

            // Let's also write something to the Console so we can see that it changed
            Console.WriteLine("You turn the vehicle on.");
        }

        // At this point we can either test this first method or create the second one, and then test
        public void TurnOff()
        {
            Console.WriteLine("You turn off the vehicle.");
            IsRunning = false;
        }

        // Let's now also create an indicate method, as well as an indicator property or two
        // Let's actually go ahead and create a new class for our Indicators (see bottom of file)
        public Indicator RightIndicator { get; set; }
        public Indicator LeftIndicator { get; set; }

        public void IndicateRight()
        {
            RightIndicator.TurnOn();
            LeftIndicator.TurnOff();
        }

        public void IndicateLeft()
        {
            LeftIndicator.TurnOn();
            RightIndicator.TurnOff();
        }

        public void TurnOnHazards()
        {
            RightIndicator.TurnOn();
            LeftIndicator.TurnOn();
        }

        public void ClearIndicators()
        {
            RightIndicator.TurnOff();
            LeftIndicator.TurnOff();
        }

        // Similar to other methods we've created so far, all C# classes have access to what's called a Constructor Method

        // A Constructor Method allows us to give arguments when the class gets initialized
        // It has a public access modifier followed by the class name
        // Also it can be noted that typically the constructor goes above the properties
        // Let's create a constructor that has a set of parameters that matches the properties
        public VehicleRefactor(string make, string model, double mileage, VehicleType type)
        {
            Make = make;
            Model = model;
            Mileage = mileage;
            TypeOfVehicle = type;
        }

        // Once we declare this constructor, we should see that our Vehicles we declared are now throwing errors
        // Why is it suddenly not working? Well, we're missing the implicit constructor now since we declared our own
        // We can now overload the constructor the same way we overloaded our methods before
        // I would put this before the other constructor
        // Once the errors are fixed, we can go back and create a new Vehicle in our Test file
        public VehicleRefactor() { }
    }

    // Here is a challenge for the students:

    // Create a class called Indicator that has a property called IsFlashing
    // IsFlashing should have a private set 
    // The Indicator class also then needs the methods required to change the state of the IsFlashing Property
    public class Indicator
    {
        public bool IsFlashing { get; private set; }

        public void TurnOn()
        {
            IsFlashing = true;
        }

        public void TurnOff()
        {
            IsFlashing = false;
        }
    }
}
