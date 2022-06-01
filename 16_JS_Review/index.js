/*  
Declare and initialize variables for each of the following:
  myName (string), 
  bestFriend (string), 
  favoriteThings (array), 
  and myPet (object - with key/value pairs of petName/string, petAge/int, isGood/boolean)
*/

let myName = "SpongeBob";
let bestFriend = "Patrick";
let favoriteThings = ["My pet snail, Gary", "Being a fry cook at the Krusty Krab", "Practicing Karate with Sandy", "Blowing bubbles", "Jellyfishing"];
let myPet = {
  petName: "Gary",
  petAge: 30,
  isGood: true
};

//------------------------------------------
// Print "Hello, my name is <Your Name>!" to the console
// console.log(`Hello, my name is ${myName}!`);

// Using DOM manipulation add an H1 tag to the main element's <div> with the id of "mainElementContent" of our HTML with the phrase above. (Hint: you can can pass your variable to a display function, set the string interpolation to a variable, etc. Use Google or refer to your Foundations notes for a refresher of an example on building the logic.)

// Remind students that "name" is the Parameter, a parameter is the data's name for the function's definition (to only be used in the function).
function displayMyName(name) {
  // Remind students to use the console to confirm data passing (comment out if working)
  // console.log(name);

  // Declare and initialize reference to the HTML main's div element
  const mainSection = document.getElementById("mainElementContent");
  // Declare and initialize the h1 element
  const nameTextTag = document.createElement("h1");
  // Declare and initialize a string interpolation value to display
  let greeting = `Hello! My name is ${name}, welcome to my JS review page.`;

  // Set the greeting value as the h1 variable's text
  nameTextTag.textContent = greeting;

  // Append h1 to main
  mainSection.appendChild(nameTextTag);
}

// Calling the displayMyName function, remind students that myName is the Argument, thus the real "value" that is being passed to the function.
displayMyName(myName);

//--------------------------------------
/*
Lets compare our name to our best friend's name and eventually add that information to the <aside> of our page!

1) Find the length of each name.
2) Write and use a conditional to see who has the longer name. Assign a string interpolation of whose name is longer to a variable and console.log it.
  Example Result: My name is longer than <shorter name>'s.
3) Update the conditional to also calculate how many letters difference there are between the two names and add that to the string interpolation.
  Example Result: My best friend <bestFriend>'s name is shorter than mine by 3 letters.

There is also one additional case that should be handled that has not been mentioned so far. See if you can add that to your conditional!
*/

// Finding the length using the .length property
// console.log(myName.length);
// console.log(bestFriend.length);

// Declaring nameMessage variable without assigning a value
let nameMessage;

if (myName.length > bestFriend.length) {
  let letters = myName.length - bestFriend.length;
  // Assigning nameMessage the string value
  nameMessage = `My best friend ${bestFriend}'s name is shorter than mine by ${letters} letters.`;
  // Students may need to make sure they did not assign nameMessage to the full console.log versus assigning the variable to just the string
  //console.log(nameMessage);
} else if (myName.length < bestFriend.length) {
  let letters = bestFriend.length - myName.length
  nameMessage = `My best friend ${bestFriend}'s name is longer than mine by ${letters} letters.`;
  //console.log(nameMessage);
} else {
  nameMessage = `My best friend ${bestFriend} and I's names are the same length!`;
  //console.log(nameMessage);
}

// Instructor, remind students to test using console.logs, doing a console.log outside of the conditional to make sure it matches the console.log output for the conditional. Also remind them to comment out/erase those logs once they see them succeed, the cleaner the console the better!
//console.log(nameMessage);

/*
Just as we have before, let's practice creating a text element and adding that via DOM manipulation to the page. 
This time we want to slightly refactor the name comparison logic from above to allow us to pass the console.log messages through to a display function.

How can we do this? There are a few ways, but let's try a basic format of:
1) Declaring a variable of nameMessage before our conditional statement.
2) In each comparison, reassign the variable to the console.log contents.
3) We now have a variable to pass to a display function, time to build another function that creates and appends a text element! Remember to add the element(s) made to the <aside> of our HTML.
*/

function displayFriendsName(message) {
  //console.log(message);

  // Declare and initialize reference to the HTML aside element
  const asideSection = document.getElementById("asideElement");
  // Declare and initialize the text element, I used an h3
  const messageTextTag = document.createElement("h3");

  // Assign the messageTextTag's text content to message parameter
  messageTextTag.textContent = message;

  // Append messageTextTag to the asideSection variable
  asideSection.appendChild(messageTextTag);
}

displayFriendsName(nameMessage);

//-------------------------------------------
/*
Let's build two more rounds of practice!
Create logic to display the contents of your favoriteThings array via DOM manipulation to our main element <div> again.

Be sure to add in a text element of an H3 to title this section's content such as "These are a few of my favorite things:" or "My favorite things are:" to make our site more approachable!

Arrays have a number of methods, use the .sort() method first to alphabetically sort your favoriteThings and then use the .forEach() method to house logic to create and add a <li> tag element for each item of our array. (Psst, don't forget what other tag is needed for list items.)

Make sure to use your resources, there are lots of creative ways to construct how this one is built and functions!
*/

function displayFavoriteThings(favorites) {
  //console.log(favorites);

  // Declare and initialize reference to the HTML main element
  const mainSection = document.getElementById("mainElementContent");
  // Declare and create elements needed for prompt
  const favoriteLabel = document.createElement("h3");
  const listContainer = document.createElement("ul");

  // Giving our h3 text
  favoriteLabel.textContent = "My favorite things are: ";

  // Using the .sort method prior to using .map(), this is a good spot to console.log before and after to see the method's effect on the array and note JS's top to bottom read.
  //console.log(favorites);
  favorites.sort();
  //console.log(favorites);

  // Using the .forEach() to perform logic per data item in the array; note for instructors: forEach doesn't change/mutate the original array nor returns a value from the callback fn which is why in this instance it is a better choice over .map() method functionality. 
  favorites.forEach(function (eachThing) {
    // For each item, create a list item element
    const listItem = document.createElement("li");
    // Assign the text content to the eachThing/favorite thing
    listItem.textContent = eachThing;
    // Append the list item to our ul/ol per favorite thing
    listContainer.append(listItem);
  });

  // Getting everything visible to the site with proper appending, if students' site "doesn't look the same" check that they have everything in the right order of appending/nesting.
  mainSection.append(favoriteLabel);
  mainSection.append(listContainer);
}

displayFavoriteThings(favoriteThings);

//------------------------------------------
/*
Now for our final round of practice! 
Let's build a way to display our pet's info to the <article> element of our page.

We can again:
1) Construct a display function.
2) Create a text element as a title for the section (H3) as well as other text elements to display our pet's name, age, and if they've been good or bad. 
3) Assign all the corresponding data to the elements. 
4) Append all our new elements to the article of our HTML.

Here are some optional fun stretch goals for adding a little extra "spice" to this one: 
- Add an img tag and give it a src of your pet (if you don't have one, check out unsplash.com for free images; also be sure to make an images folder to hold your local media files).
- Create a if/else that prints a detailed phrase if they've been good or bad. 
- Construct a conditional depending on their age if they're a puppy/kitten, adult, or senior.
*/

function displayPetInfo(pet) {
  // console.log(pet);

  // Declare and initialize reference to the HTML article element
  const articleSection = document.querySelector("#articleElement");
  // Declare and create elements needed for prompt
  const petLabel = document.createElement("h3");
  const petNameElement = document.createElement("p");
  const petAgeElement = document.createElement("p");
  const petBooleanElement = document.createElement("p");

  // Creating an Img tag and assigning attributes
  const petImage = document.createElement("img");
  petImage.src = "https://media.giphy.com/media/xT3i18koYnLgXczyzS/giphy.gif";
  petImage.style = "height: 250px; width: 250px";

  // Logic for isGood value conditional
  let isGoodMessage;
  if(pet.isGood === true) {
    isGoodMessage = `It's ${pet.isGood}, my sweet ${pet.petName} is a very very good snail companion.`;
  } else {
    isGoodMessage = `Oh, is ${pet.petName} being good? Unfortunately that's ${pet.isGood}... He keeps leaving snail trails all over the house!`;
  }
  // Assigning the message's string value to the text of the p tag
  petBooleanElement.innerText = isGoodMessage;

  // Logic for age conditional (I goggled cat age ranges for these numbers (Kitten is birth to 1 year, Young Adult is 1-6 years, Mature Adult is 7-10 years, and senior is 10+ years). Dog age ranges so you don't have to look it up are: 6-24 months as Adolescent/Puppy, 2-6 years for adult, 7-9 years as senior (but it ultimately depends on the specific breed ¯\_(ツ)_/¯ )).
  let petAgeMessage;
  if(pet.petAge <= 1) {
    petAgeMessage = `My ${pet.petName} is only ${pet.petAge} year old! He's just a lil' snail-kitten.`;
  } else if (pet.petAge <= 6) {
    petAgeMessage = `My ${pet.petName} is ${pet.petAge} years old! He's a young adult in Bikini Bottom snail years.`;
  } else if (pet.petAge <= 10) {
    petAgeMessage = `My ${pet.petName} is now ${pet.petAge} years old! He's a mature adult in all his mature-snail glory.`;
  } else {
    petAgeMessage = `My ${pet.petName} is ${pet.petAge} years old. Although he's a senior, he looks great and acts like he's in his  snail-prime.`;
  }
  // Assigning the message's string value to the text of the p tag
  petAgeElement.innerText = petAgeMessage;

  // Assigning text content to the other text elements, students may not have seen or used innerText, similar to textContent's functionality 
  petLabel.innerText = "Here's some info on my other best friend, my pet: ";
  petNameElement.innerText = `His name is ${pet.petName}!`;

  // These were the assignments for the basic solution, stretch goal solution is currently in use
  // petAgeElement.innerText = `He is ${pet.petAge} years old! (He looks great for his age, I know.)`;
  // petBooleanElement.innerText = `It's ${pet.isGood}, he is a very good boy. The best companion a sponge could ask for!`;

  // Appending elements, append (versus appendChild) does allow for multiple elements/text nodes to be appended in the same method. Students will most likely use appendChild and append each individually.
  // Useful to note that although things were assigned values in different sections above, the order that they are appended here effects the order they will append/appear on the page.
  articleSection.append(petLabel, petImage, petNameElement, petAgeElement, petBooleanElement);
};

displayPetInfo(myPet);