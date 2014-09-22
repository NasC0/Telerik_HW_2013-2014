// Task 1 + 4: Assign all the possible JavaScript literals to different variables.
var jsString = "five";
var jsInt = 5;
var jsDouble = 5.5;
var jsBool = true;
var jsUndefined;
var jsNull = null;
console.log("String: " + jsString);
console.log("Int: " + jsInt);
console.log("Double: " + jsDouble);
console.log("Bool: " + jsBool);
console.log("Undefined: " + jsUndefined);
console.log("Null: " + jsNull);

// Task 2: Create a string variable with quoted text in it.
var quotedString = '"How you doin\'?", Joey said';
console.log(quotedString);

// Task 3 + 4: Try typeof on all variables you created.
console.log(typeof(jsString));
console.log(typeof(jsInt));
console.log(typeof(jsDouble));
console.log(typeof(jsBool));
console.log(typeof(jsUndefined));
console.log(typeof(jsNull));
if (jsUndefined === undefined) {
    console.log(jsUndefined + " is not a number: " + typeof(jsUndefined));
}