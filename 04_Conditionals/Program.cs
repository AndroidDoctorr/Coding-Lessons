// IF STATEMENTS

// Now that we're aware of how to compare values in C#, what do we do with this knowledge?
// Typically we'll set up chunks of code to execute only if a condition, like the ones we've explored before, is met

// To show this off we'll introduce the most basic of conditionals, an if statement
// Most people don't think about it, but we run our lives off of boolean logic
// If hungry, eat. If tired, sleep. If bad, get good. We can show this here

// We'll start with a simple boolean value. We can change this to show different outcomes
bool userIsHungry = true;
if (userIsHungry)
{
    // Put code that should fire off if the userIsHungry condition is true inside these braces
    Console.WriteLine("Eat something!");
}

// Again we'll create a simple bit of default data with this variable
int hoursSpentStudying = 1;
if (hoursSpentStudying < 16)
{
    Console.WriteLine("Are you even trying?");
}

// ELSE

// Now that we have the ability to do something if our defined condition is met, we can add another step
// If our condition is met, do A. For anything else, do B.

// Here we have a boolean. We can change it to see the different routes
bool choresAreDone = false;
if (choresAreDone) //-- This is the condition for both the if and else
{
    // If the condition evaluates as true, we'll run the first section
    Console.WriteLine("Have fun at the movies!");
}
else //-- Just the else keyword without another condition
{
    // If the condtion does not evaluate as true, we run this chunk of code
    Console.WriteLine("You must stay home and finish your chores!");
}

// Obviously we cannot have an else without an if first

// Here we're introducing the concept of simulating user input
// If the user is submitting a string we can't compare it so we need to convert it
string input = "7";
int totalHours = int.Parse(input);

if (totalHours >= 8) //-- first if
{
    Console.WriteLine("You should be well rested.");
}
else //-- first else, just like what we saw before
{
    Console.WriteLine("You might be tired today.");

    // Here you can see another if statement embedded inside our first if's else
    if (totalHours < 4) //-- second if
    {
        Console.WriteLine("You should get more sleep!");
    }
}

// Sometimes we'll know that we're going to need to check multiple conditions
// You might see a stack of if else statements, so let's make one

int age = 7;
// Here we have chained if else statements.
if (age > 17)
{
    Console.WriteLine("You're an adult.");
}
else
{
    if (age > 6) //-- Notice there's nothing inside the first else statement before the if
    {
        Console.WriteLine("You're a kid.");
    }
    else if (age > 0) //-- This time we just put the if right after the else so it reads easier
    {
        Console.WriteLine("You're far too young to be on a computer");
    }
    else
    {
        Console.WriteLine("You're not born yet.");
    }
}

// Here we can show off the AND, OR, EQUAL, and NOT EQUAL operators again
if (age < 65 && age > 18)
{
    // And comparison
    Console.WriteLine("Age is between 18 and 65.");
}

if (age > 65 || age < 18)
{
    // Or comparison
    Console.WriteLine("Age is either greater than 65 or less than 18.");
}

if (age == 21)
{
    // Is equal to
    Console.WriteLine("Age is equal to 21.");
}

if (age != 36)
{
    // Not equals to
    // Bang operator
    Console.WriteLine("Age is not equal to 36.");
}


// SWITCH CASES

// If statements are great for boolean statements
// My age is greater than 18. I am of the type Human. These are both booleans.
// My age is either greater than 18 or it is not. I am either an instance of the Human type or I am not.
// It gets a little wordy if we're wanting to check a lot of different instances though. For that we can use a switch case

// The structure is as follows:
//  The switch keyword.
//  The value being evaluated (Located in the parentheses)
//  The cases { Located in the curly braces }
//    Each case has the keyword "case" followed by the value expected.
//    If we're evaluating (age), I might have a "case 18:"
//      After the case comes the code that will execute if this case is met.
//      Each case also has to have some sort of escape.
//      Often this will be done with a "break;" at the end.

int intInput = 1;

switch (intInput)
{
    case 1:
        Console.WriteLine("Hello");
        break;
    case 2:
        Console.WriteLine("What you doing?");
        break;
    default:
        Console.WriteLine("This is default. It will execute if no other case is evaluates as true. Defaults are not required.");
        break;
}

// Day of the week
string today = "Tuesday";

switch (today)
{
    case "Monday":
    case "Tuesday":
    case "Wednesday":
    case "Thursday":
    case "Friday":
        Console.WriteLine("Hope you're ready to work!");
        break;
    case "Saturday":
    case "Sunday":
        Console.WriteLine("Sorry we're closed.");
        break;
}

// We can also stack cases if we know they'll execute the same code
int myAge = 37;

switch (myAge)
{
    case 18:
        // Code for 18 year olds
        break;
    case 19:
        // Code for 19 year olds
        break;
    case 20:
        // Code for 20 year olds
        break;
    case 21: //-- Here we see we can stack cases together over one chunk of code
    case 22:
    case 23:
        // Code for ages from 21-23
        break;
    default:
        // If no specific case is met then you can use a default set of code
        break;
}

// Another thing you can do (thanks to C# 8) is use Switch Expressions
// A Switch Expression is a switch statement that allows you to assign directly to a variable

// Let's show a Switch Case and then the Expression equivalent

string output;
int action = 1;

// Switch Case Statement
switch (action)
{
    case 0:
        output = "Case 0";
        break;
    case 1:
        output = "Case 1";
        break;
    case 2:
        output = "Case 2";
        break;
    default:
        output = "Default Case";
        break;
}

Console.WriteLine(output);

action = 2;

// Switch Expression
output = action switch
{
    0 => "Case 0",
    1 => "Case 1",
    2 => "Case 2",
    _ => "Default Case"
};

Console.WriteLine(output);


// TERNARY EXPRESSIONS

int userAge = 31;

// Here's oure Ternary structure
// (Condition/Boolean) ? trueResult : falseResult;
bool isAdult = (userAge > 17) ? true : false;
Console.WriteLine("Age is over 17: " + isAdult);

int numOne = 10;
int numTwo = (numOne == 10) ? 30 : 20;
Console.WriteLine(numTwo);

// Here we can see we're not just assigning a variable some value
// Instead, the output is being passed into the WriteLine method
Console.WriteLine((numTwo == 30) ? "True" : "False");