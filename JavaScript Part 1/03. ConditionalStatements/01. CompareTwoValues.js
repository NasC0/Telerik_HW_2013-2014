///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 1. Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one. //
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var firstNumber = 5;
var secondNumber = 10;

if (firstNumber > secondNumber) {
    console.log("Exchanging values.");
    console.log("First number before switch: " + firstNumber);
    console.log("Second number before switch: " + firstNumber);
    var temp = secondNumber;
    secondNumber = firstNumber;
    firstNumber = temp;

    console.log("First number after switch: " + firstNumber);
} else {
    console.log("No switch necessary.");
    console.log(firstNumber);
}