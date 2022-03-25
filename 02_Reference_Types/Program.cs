// STRINGS

// Earlier we discussed characters, and how we can store them as their own variable
// But if we want to store a word, we don't want to declare a ton of individual variables, we want just the one
// Instead of having six variables for the name Joshua, we can just store one string

// Like other types we can simply declare a variable of the string type
string thisIsDeclaration;

// We can also declare and then later initialize a value
string declared;
declared = "This is initialized.";

// Declaration and Initialization
string declarationAndInitialization = "This is both declaring and initializing.";


//-- Manipulating Strings
// Let's start out with our first and last names
string firstName = "Andrew";
string lastName = "Torr";

// Here we see concatenation. This is where we take different values and smash them together, more or less
// Why are we adding the " " part between the first and last names?
string concatenatedFullName = firstName + " " + lastName;

// We also have what's called composite formatting, where you declare a space for a variable and then later give the variables
// While this part will probably make more sense later once we start talking about methods, you can see here we're using curly braces and indexes (starting at 0) to place variables into the given string.
// Remember that our enum we saw in the ValueTypeExamples also defaulted to starting at 0.
string compositeFullName = string.Format("{0} {1}", firstName, lastName);

// Here we're using string interpolation
// It's similar to composite formatting, but instead of indexes we plug the variables in directly to the string
// Notice the $ in front of the string. This is very important!
string interpolatedFullName = $"{firstName} {lastName}";

Console.WriteLine(firstName);
Console.WriteLine(lastName);
Console.WriteLine(concatenatedFullName);
Console.WriteLine(compositeFullName);
Console.WriteLine(interpolatedFullName);

// COLLECTIONS

// When programming, we're clearly able to make a lot of variables
// Sometimes we want to reference multiple items at once, just like with strings
// A string is just a collection of characters
// If we want a group of some other type, we'll use one of our collection types

//-- Arrays
// We'll start by declaring a string so that we can use it in our array, our first type of collection
string stringExample = "Hello World!";

// Here we're declaring our array, using the square brackets []
// Notice the type that the array holds is given before the brackets, in this case it's string[]. This means this array only holds strings
string[] stringArray = { "Hello", "World!", "Why", "is it", "always", stringExample, "?" };

// We can use these square brackets to read or write to a specific index
// Here we're reading from the index with the value of 2, or the third item (0, 1, 2...)
string thirdItem = stringArray[2];
Console.WriteLine(thirdItem);

// Here we're instead writing to the index with the value of 0, or the first item
stringArray[0] = "Hey there";
// We can now see the change by reading from that index and writing it to the console.
Console.WriteLine(stringArray[0]);


//-- Lists
// You'll need to bring in the using namespace for collections here
// This is a good time to mention the using statements at the top of the file
// Using statements allow us to "use" code that is written somewhere else
List<string> listOfStrings = new List<string>();
List<int> listOfIntegers = new List<int>();

listOfStrings.Add("First string for our list");
listOfIntegers.Add(461012);

// We can also reference items in Lists with their index
Console.WriteLine(listOfIntegers[0]);


//-- Queues
// Here we new up a new Queue that holds strings
Queue<string> firstInFirstOut = new Queue<string>();

// Unlike Lists, we have the Enqueue method instead of an Add method to add items to the Queue
firstInFirstOut.Enqueue("I'm first!");
firstInFirstOut.Enqueue("I'm next!");

string firstItem = firstInFirstOut.Dequeue();
Console.WriteLine(firstItem);


//-- Dictionaries
// Here we're declaring a new Dictionary that has int as its key type and string as its value type
Dictionary<int, string> keyAndValue = new Dictionary<int, string>();

// With our dictionary now declared, we can add something to it with the Add method
// Notice we need to give it both the Key's value and the Value's value
keyAndValue.Add(7, "Agent");

string valueSeven = keyAndValue[7];
Console.WriteLine(valueSeven);

//-- Other Collection Examples
// Here are a few other collection types we won't be diving into right now but we want to show off
SortedList<int, string> sortedKeyAndValue = new SortedList<int, string>();
HashSet<int> uniqueList = new HashSet<int>();
Stack<string> lastInFirstOut = new Stack<string>();