// WHILE LOOPS

// Occasionally when programming you'll find yourself needing to repeat some code execution
// In C# we have a few different ways to do this, and now we'll focus on loops

// A while loop checks a condition and loops WHILE the condition is true
// For now we'll start by checking an int value
int total = 1;

// The structure is as follows
// while (condition) { body }
while (total != 10)
{
    Console.WriteLine(total);
    // Here at the end of the code execution we add 1 to total's value and reassign it
    total = total + 1;
}

// Let's reset total and start again
total = 0;

// Remember if the condition is true it loops. So a conditional value of true will loop forever
while (true)
{
    if (total == 10)
    {
        Console.WriteLine("Goal reached.");
        // We can instead use the break keyword (same as with switch cases) to break out of a loop
        break;
    }

    // Here we're seeing the compound assignment used instead of what we used above
    total++;
}

// We'll show another example, where instead of true we assign an actual boolean variable
// To show off an unknown amount of iterations, we can use a Random type variable
Random rand = new Random();

// Here we're going to create some data for our next loop
int someCount;
bool keepLooping = true;

while (keepLooping)
{
    // Here we're seeing we can grab a random value from the Random variable we created above
    // This method will return an int between the range of 0 (inclusive) and 20 (exclusive)
    someCount = rand.Next(0, 20);

    // We can also skip an iteration with the continue keyword
    if (someCount == 6 || someCount == 10)
    {
        continue;
    }

    Console.WriteLine(someCount);

    // Finally what we'll do is check for an exit condition and update our boolean
    if (someCount == 15)
    {
        keepLooping = false;
    }
}



// FOR LOOPS


// Another type of loop we'll see is the For loop, that iterate a certain amount of times
// Some of our previous loops have acted like For loops, where they just count up

// Let's start by grabbing the class count as a end point
int studentCount = 21;

// Now let's look at the For Loop structure:
// for keyword
// 1 Starting Point
// 2 While this condition is true, keep looping
// 3 What we do after each loop
// 4 Code we execute each loop
//for   //1         //2           //3
for (int i = 0; i < studentCount; i++) // i = i + 1
{
    //4
    Console.WriteLine(i);
}

// Now that we've seen the structure, let's look at a more concrete example
// Let's create a collection of students (This can be a challenge for the students)
string[] students = { "Adam", "Justin", "Joshua", "Amanda", "Danielle", "Ingeborg" };

// Here we'll execute a line of code until we have reached the last student
for (int i = 0; i < students.Length; i++)
{
    Console.WriteLine($"Welcome to class {students[i]}!");
}

// FizzBuzz is another good example of using a for loop, students should have done that in the prework

// Now we've seen how we can set up loops for a certain count, but we can take that student greeting and slim it down
// With a foreach loop, you can pass a collection to the loop and execute the same code for each item in the collection


// FOREACH LOOPS


// Let's bring that collection of students back again
string[] students = { "Adam", "Justin", "Joshua", "Amanda", "Danielle", "Ingeborg" };

//1 Collection being worked on
//2 Name of the current iteration
//3 Type in the collection
//4 in keyword used to seperate the individual and the collection
//foreach //3  //2  //4  //1
foreach (string student in students)
{
    Console.WriteLine(student + " is a student in the class.");
}

// Remember how we mentioned before that a string is a collection of char?
// We can foreach through a string as well!
string myName = "Joshua Lee Tucker";
foreach (char letter in myName)
{
    if (letter != ' ')
    {
        Console.WriteLine(letter);
    }
}


// The last loop type we have is called a do while loop
// The difference with a do while and a while loop is that a do while will execute at least once
// It does not check the condition until after the first execution


// DO WHILE LOOPS


// Just like all other loops, we use the keywords from the loop name
int iterator = 0;
do
{
    Console.WriteLine("Hello!");
    iterator++;
}
while (iterator < 5);

// We can also see it executes once even if the condition is false
do
{
    Console.WriteLine("My do while condition is false!");
}
while (false);

// Compare that to this while loop with a false condition
while (false)
{
    // Notice Visual Studio's linter is telling us the code is unreachable
    Console.WriteLine("My while condition is false!");
}

