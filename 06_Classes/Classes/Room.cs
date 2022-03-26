namespace _06_Classes.Classes
{
    public class Room
    {
        // Let's talk about the const keyword
        // const allows us to create a variable that has a CONSTANT value, one that can never change no matter what
        // In defining our Room class, we want to put some constraints for defining the size of the room
        private const double MaxLength = 30;
        private const double MinLength = 6;

        private const double MaxWidth = 30;
        private const double MinWidth = 6;

        private const double MaxHeight = 12;
        private const double MinHeight = 9;

        // After this, we want to define our Length, Width, and Height properties
        // We want to be customizing our setters we want to make a full property, including a backing field
        // We'll include all of our backing fields together and the methods below them
        // This will allow us to keep our class organized (const, fields, constructor, properties, methods)
        private double _length;
        private double _width;
        private double _height;

        // Once we have our properties added, we want to create our only constructor that sets the dimensions
        public Room(double length, double width, double height)
        {
            // Notice we're setting not the field, but the property
            // This allows us to utilize our setter when assigning the value
            // Otherwise we would bypass it, and our values could be set incorrectly
            Length = length;
            Width = width;
            Height = height;
        }

        // We have our first property, Length, that we want to set up
        // In this we want to have it return the value stored at _length when read
        // When set, we want to assign the value to the _length field if a valid value is given
        public double Length
        {
            // Here we're just simply returning the backing field
            // Because we're customizing our set, the _length field should only update if a valid value is given
            get { return _length; }

            // This is a private setter, this means we can only access this setter from inside this class
            private set
            {
                // Our first step before assigning our value is to check if we have broken either of our constraints
                // We're using the or operator to check if either of the conditions is true
                // If we meet the minimum but excede the maximum
                if (value < MinLength || value > MaxLength)
                {
                    // This is the first time the student should be seeing an exception in their code
                    // Make sure to talk about this and possibly even pull up the docs
                    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/
                    throw new ArgumentException($"The length should be between {MinLength} and {MaxLength} inclusive.");
                }

                // If we've gotten this far, that means we have not thrown the above exception
                // This means our value is valid and we can now assign it to our backing field
                _length = value;
            }
        }

        // We'll now need to complete the changes to our Width and Height properties as well
        // They will look very similar to the Length property above
        public double Width
        {
            get { return _width; }
            private set
            {
                if (value < MinWidth || value > MaxWidth)
                {
                    throw new ArgumentException($"The width should be between {MinWidth} and {MaxWidth} inclusive.");
                }

                _width = value;
            }
        }

        public double Height
        {
            get { return _height; }
            private set
            {
                if (value < MinHeight || value > MaxHeight)
                {
                    throw new ArgumentException($"The height should be between {MinHeight} and {MaxHeight} inclusive.");
                }

                _height = value;
            }
        }

        // Once we're done with our consts, fields, properties, and constructor we need to add our methods
        // We'll start with our square footage calculation
        public double CalculateSquareFootage()
        {
            // To calculate square footage we're just going to multiply the length by width
            double squareFootage = Length * Width;
            return squareFootage;
        }

        // Calculating the lateral surface area is definitely a "google it" kind of situation
        // We're looking to calculate the surface area of everything aside from the bases
        // We can do this by calculating the walls and adding them together
        public double CalculateLateralSurfaceArea()
        {
            // To calculate the Lateral Surface Area (LSA) we're multiplying the length/width by height for both walls
            // Notice here we're using the fields instead of the properties like we did above
            // The point here is that we can use the private fields inside the class
            double lengthLSA = _length * _height * 2;
            double widthLSA = _width * _height * 2;
            return lengthLSA + widthLSA;
        }
    }
}