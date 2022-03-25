// This is all defined in the GitBook instructions.
// There are some extra bits in here, you can ignore them, or you can include them if you have time.

// First function - tied to a button in the HTML page
function doSomething() {
  const nameInput = document.getElementById("nameInput");
  // nameInput = 3;
  const name = nameInput.value;
  alert(`hello ${name}!`);

  $.ajax("https://swapi.dev/api/people/1")
    .then((data) => alert(data["name"]))
    .catch((e) => alert(e.message));
}

function doSomethingElse() {
  // Demonstrage several types at once:
  const someArray = [
    1,
    true,
    "hello",
    {
      foo: "bar",
      toString: () => {
        return "poop";
      },
    },
    null,
    undefined,
  ]; // This is OK according to JavaScript

  // Grab the container div so we can add children to it (this comes later)
  const container = document.getElementById("container");

  // Demonstrate a
  someArray.forEach((thing) => {
    // truthiness
    // falsy: 0, null, undefined, false, ""
    // truthy: [], 1 2 3..., true, {}

    // start by alerting each item
    alert(thing);
    if (thing) {
      // built-in alert method
      //alert(thing.toString());

      // built-in console method
      console.log(thing);

      // addElement function
      addElement(container, thing);
    }
  });

  // Talk about the difference between map and forEach (map returns an altered array, forEach just does a thing for each element)
  someArray.map();

  // Demo a for loop
  for (var i = 0; i < 20; i++) {
    // Ask the students what the output of this will look like before running it
    console.log("i: " + i);
  }

  // () => {} // this is a function in JS
  // It's anonymous function because it doesn't have a name
  // It's also a noop because it doesn't do anything
  // like null but a function
}

function addElement(container, thing) {
  let newDiv = document.createElement("div");
  newDiv.append(thing.toString());
  container.appendChild(newDiv);
}

// DOM = Document Object Model
/*
  {
      html: {
          head: {}
          body: {
              ...
              div: {
                  ...
                  form: {
                      ...
                      input: {
                          type: "text",
                      },
                      input: {
                          type: "button",
                          value: "Click me!"
                      }
                  }
              }
          }
      }
  }
  */
