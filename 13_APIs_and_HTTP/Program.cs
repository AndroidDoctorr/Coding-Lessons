// Before getting into the code, we're going to talk about APIs
// What is an API? Have the students look into this
// Let's download postman so we can call our first API
// We'll be calling the SWAPI api for today's exercise https://swapi.dev


// IMPORTANT FOR .NET 6!!
// We also need to install a formatting extension for http:

// dotnet add package System.Net.Http.Formatting.Extension

// As well as the Newtonsoft JSON translation package:

// dotnet add package Newtonsoft.Json


// Also have the students look into Async/Await
// Async and Await, if you've done any research into it, can be a very overcomplicated subject
// Why are we combining these two? HttpClient uses async code

// Let's now see what we can do in C#
// Start by adding an instance of HttpClient (Notice we'll have to bring in a using statement=> System.Net.Http)
HttpClient httpClient = new HttpClient();

// Just like in Postman, what we can do is just call a GET request
// Let's declare a variable to capture our response value
// We don't necessarily know the type, so we can use var => More you read code the better this will work
// When we do hover over our .GetAsync() method, we'll see we get an Task<HttpResponseMessage>
// Let's use that instead by accessing the .Result
HttpResponseMessage response = httpClient.GetAsync("https://swapi.dev/api/people/1").Result;

// Let's run and see what our response looks like. Use a breakpoint
// Our response's Content property is going to be an HttpContent which doesn't necessarily help right now

// Let's see what properties it does have. We should see a suggested property of .IsSuccessStatusCode
// We can use that in an if statement to check if we should try to use it

if (response.IsSuccessStatusCode)
{
    // We can tap into the methods for this class though, let's try ReadAsStringAsync() and grab it's .Result
    Console.WriteLine(response.Content.ReadAsStringAsync().Result);

    // Now there's not a ton we can immediately do with this information
    // We're currently getting a JSON return type. What is JSON?
    // In JavaScript (different than Java) that would be fine, you just know what values you want and just use dot notation to grab them
    // Because C# is strongly Typed, we need to have an object so we can define its properties

    // We COULD write some code to parse through that string and turn it into something for us, or we can install a package that does it for us
    // Take a minute and see if there's something you can find to turn it into an object for us (students)
    // I'm going to want to use ReadAsAsync(), which is a method we will get by adding the Microsoft.AspNet.WebApi.Client nuget package

    // Now we can try our ReadAsAsync, but we'll notice a problem. We need a Type to use
    // Let's add a Models folder that we can add our custom response model types to
    // Since we're using the people route, let's make a Person class
    // Do we know what properties we need? Maybe check our response here or in Postman

    // Defining models is tedious right now, but once we're defining our own API it will be easier since we'll have already defined our models
    // You'll have to define models for your front and back ends all the time, so get used to it

    // Let's now add our ReadAsAsync with our Person type
    Person personResponse = response.Content.ReadAsAsync<Person>().Result;
    Console.WriteLine(personResponse.Name); //-- Breakpoint this

    // We can also go ahead and use the list of vehicles we get with our person and get their information as well
    foreach (string vehicleUrl in personResponse.Vehicles)
    {
        HttpResponseMessage vehicleResponse = httpClient.GetAsync(vehicleUrl).Result;
        Console.WriteLine(vehicleResponse.Content.ReadAsStringAsync().Result);
        // We'll also need to define our Vehicle type, just like we did for our Person class
        // After we define our Vehicle class, we can call the ReadAsAsync<Vehicle>() method off our response
        Vehicle vehicle = vehicleResponse.Content.ReadAsAsync<Vehicle>().Result;
        Console.WriteLine(vehicle.Name);
    }
}

// See how every time we want to get something, we have to call multiple properties and different methods?
// Let's not go ahead and create our own little code repository to use so we can start building out some custom methods
// For this, I'm going to use another name, service, and add our new class SWAPIService
SWAPIService swapiService = new SWAPIService();

// Person personTwo = httpClient.GetAsync("https://swapi.dev/api/people/11").Result.Content.ReadAsAsync<Person>().Result;
Person personTwo = swapiService.GetPersonAsync("https://swapi.dev/api/people/11").Result;
if (personTwo != null)
{
    Console.WriteLine(personTwo.Name);

    // Let's now write out a method that gets us a Vehicle class from our Service
    foreach (string vehicleUrl in personTwo.Vehicles)
    {
        Vehicle vehicle = swapiService.GetVehicleAsync(vehicleUrl).Result;
        Console.WriteLine(vehicle.Name);
    }
}

// Okay so now we have two methods in our Service that look very similar
// Let's refactor them and add a generic method

// Let's use our new method we made
Vehicle genericResponse = swapiService.GetAsync<Vehicle>("https://swapi.dev/api/vehicles/4").Result;
if (genericResponse != null)
{
    Console.WriteLine(genericResponse.Name);
}
else
{
    Console.WriteLine("Targeted object does not exist.");
}

// Now SWAPI also has the ability to search. Let's go ahead and add a search method to our service
SearchResult<Person> skywalkers = swapiService.GetPersonSearchAsync("skywalker").Result;
foreach (Person person in skywalkers.Results)
{
    Console.WriteLine(person.Name);
}