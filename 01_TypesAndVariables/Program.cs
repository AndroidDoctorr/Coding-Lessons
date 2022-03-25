// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// BOOLEANS

// This will show the students the variables before and after they are initialized
// Here we've declared a variable called declared
bool isDeclared;

// Now we've called our variable and assigned a value to it
isDeclared = true;

// In this example, we're declaring AND initializing it all at once
// Notice with our name we're using camelCase style
bool isDeclarationAndInitialized = false;

// You can call a variable by its name and assign it a new value even if it has a value already.
isDeclarationAndInitialized = true;

// CHARACTERS

// To define a single character, make sure to use single quotes ('')
char character = 'a';
char symbol = '?';
char number = '7';
char space = ' ';
char specialCharacter = '\n';

// NUMBERS

// Here we just have a lot of whole numbers
// You don't have to go into much detail, it's just nice to show the students there are options
byte byteExample = 255;
sbyte sByteMax = -128;
short shortExample = 32767;
Int16 anotherShortExample = 32000;
int intMin = -2147483648;
Int32 intMax = 2147483647;
long longExample = 9223372036854775807;
Int64 longMin = -9223372036854775808;

int a = 15;
int b = -10;

byte numByte = 25;

Console.WriteLine(numByte);
Console.WriteLine((char)numByte);

// DECIMALS

float floatExample = 1.045231f;
double doubleExample = 1.789053278907036d;
decimal decimalExample = 1.2578907289045789789789789787897m;

// Notice we can type as much as we want for our types with decimals
// This does not mean it holds this value. Write it to the console to see what shows up
// This gives the students a nice example of seeing the Test output as well

Console.WriteLine(1.2578907289045789789789789787897f);
Console.WriteLine(1.2578907289045789789789789787897d);
Console.WriteLine(1.2578907289045789789789789787897m);

// STRUCTS

// If we hover over the int keyword intellisense will show us that it is a struct
// An int is actually an Int32 (as mentioned above) but we can use the given keyword instead
Int32 age = 42;

// There are other structs we will interact with as well
// One common example is the DateTime struct, which allows us to track Dates and Times
DateTime today = DateTime.Today;

// We can also create our own custom values by using the new keyword and the Constructor
DateTime birthday = new DateTime(1972, 6, 20);

// We'll see this new keyword more as we start working with more complex objects
// This keyword literally creates a NEW instance of whatever type you're using, allocating memory for the new object
// We will talk more about constructor methods in the future