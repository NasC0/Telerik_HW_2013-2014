///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 2. Write a script that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements. //
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var firstNumber = 5;
var secondNumber = -5;
var thirdNumber = -3;

if (firstNumber < 0 && secondNumber < 0 && thirdNumber < 0) {
    console.log("The product of these numbers will be negative.");
} else if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0) {
    console.log("The product of these numbers will be positive.");
} else if ((firstNumber < 0 && secondNumber < 0 && thirdNumber > 0) || (firstNumber < 0 && secondNumber > 0 && thirdNumber < 0) || (firstNumber > 0 && secondNumber < 0 && thirdNumber < 0)) {
    console.log("The product of these numbers will be positive");
} else if ((firstNumber < 0 && secondNumber > 0 && thirdNumber > 0) || (firstNumber > 0 && secondNumber > 0 && thirdNumber < 0) || (firstNumber > 0 && secondNumber < 0 && thirdNumber > 0)) {
    console.log("The product of these numbers will be negative");
}