/////////////////////////////////////////////////////////////////////////////////////////////////
// Task 3. Write a script that finds the biggest of three integers using nested if statements. //
/////////////////////////////////////////////////////////////////////////////////////////////////

var firstInt = 5;
var secondInt = 10;
var thirdInt = 15;

if (firstInt > secondInt) {
    if (firstInt > thirdInt) {
        console.log(firstInt + " is the biggest integer.");
    } else {
        console.log(thirdInt + " is the biggest integer.");
    }
} else if (secondInt > firstInt) {
    if (secondInt > thirdInt) {
        console.log(secondInt + " is the biggest integer.");
    } else {
        console.log(thirdInt + " is the biggest integer");
    }
}