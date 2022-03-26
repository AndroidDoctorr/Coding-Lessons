using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Classes.Members._00_Classes
{
    // Now we can move on to creating another class, this time we'll have one that uses our Vehicle class as a property type
    // What kind of object would have a car associated with it?
    // Let's make a Person class
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
    }
}
