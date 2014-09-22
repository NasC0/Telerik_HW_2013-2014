//////////////////////////////////////////////////////////////////////////
// Task 7. Write a script that finds the greatest of given 5 variables. //
//////////////////////////////////////////////////////////////////////////

var firstVal = 1;
var secondVal = 2;
var thirdVal = 3;
var fourthVal = 4;
var fifthVal = 5;
var biggest;

if (firstVal > secondVal && firstVal > thirdVal && firstVal > fourthVal && firstVal > fifthVal) {
    biggest = firstVal;
} else if (secondVal > firstVal && secondVal > thirdVal && secondVal > fourthVal && secondVal > fifthVal) {
    biggest = secondVal;
} else if (thirdVal > firstVal && thirdVal > secondVal && thirdVal > fourthVal && thirdVal > fifthVal) {
    biggest = thirdVal;
} else if (fourthVal > firstVal && fourthVal > secondVal && fourthVal > thirdVal && fourthVal > fifthVal) {
    biggest = fourthVal;
} else {
    biggest = fifthVal;
}

console.log(biggest + " is the greatest (dat double meaning hue-hue).");