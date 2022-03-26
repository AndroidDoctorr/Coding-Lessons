using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Classes.Members._00_Classes
{
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

        // Once we have a few different properties added create a couple instances of our Vehicle class in our test file
    }
}
