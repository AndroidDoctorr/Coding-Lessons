const doSomething = () => {
  // alert("I did something!");
  //
  // object prototype
  // https://developer.mozilla.org/en-US/docs/Learn/JavaScript/Objects/Object_prototypes
  //
  // let { three, five, six } = returnMultiple();
  // alert(three);
  // alert(five);
  // alert(six);
  //
  // spreadOperator();
  //
  // otherOperators();
  //
  // let otherCounter = { ...counter };
  // alert(counter.next());
  // alert(counter.next());
  // alert(counter.next());
  // alert(otherCounter.next());
  //
  inception().howDeepAmI();
  inception().goDeeper().goDeeper().howDeepAmI();
  inception().goDeeper().goDeeper().goDeeper().howDeepAmI();
  inception().goDeeper().goDeeper().goDeeper().kick().howDeepAmI();
};

// multiple return values from a function

const returnMultiple = () => {
  const four = {};
  const five = null;

  return { one: 5, two: 8, three: "test", four, five };
};

// the ... (spread) operator

const spreadOperator = () => {
  const someObj = { a: 1, b: 2, c: 3 };
  let anotherObj = someObj;
  someObj.a = 55;

  alert(anotherObj.a);

  anotherObj = { ...someObj };
  someObj.a = 999;

  alert(anotherObj.a);
};

// other operators - ||  ??  void  ,

const otherOperators = () => {
  var a = null;
  alert(a || "nope");

  var b = false;
  alert(b ?? "yep");

  var c = 3;
  alert(void c);

  let x = 2;
  let y = 3;
  x = ((z = x * y), ++z, z);
  alert(x);
};

// the 'this' keyword

const counter = {
  count: 0,
  next: function () {
    return ++this.count;
  },
};

const inception = function (upper) {
  return {
    // Layer object
    layer: (upper && upper.layer + 1) || 1,
    goDeeper: function () {
      return inception(this);
    },
    howDeepAmI: function () {
      alert(`Layer ${this.layer}`);
    },
    kick: function () {
      return upper;
    },
  };
};
