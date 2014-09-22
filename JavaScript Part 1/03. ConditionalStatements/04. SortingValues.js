////////////////////////////////////////////////////////////////////////////////
// Task 4. Sort 3 real values in descending order using nested if statements. //
////////////////////////////////////////////////////////////////////////////////

var firstValue = 5;
var secondValue = 10.231;
var thirdValue = -0.123;

if (firstValue > secondValue) {
    if (firstValue > thirdValue) {
        var temp;
        if (thirdValue > secondValue) {
            temp = secondValue;
            secondValue = thirdValue;
            thirdValue = temp;
        }

        console.log(firstValue + " " + secondValue + " " + thirdValue);
    } else {
        var temp = firstValue;
        firstValue = thirdValue;
        thirdValue = secondValue;
        secondValue = temp;

        console.log(firstValue + " " + secondValue + " " + thirdValue);
    }
} else if (secondValue > firstValue) {
    if (secondValue > thirdValue) {
        var temp = 0;

        if (thirdValue > firstValue) {
            temp = firstValue;
            firstValue = thirdValue;
            thirdValue = temp;
        }

        temp = secondValue;
        secondValue = firstValue;
        firstValue = temp;

        console.log(firstValue + " " + secondValue + " " + thirdValue);
    } else {
        var temp = firstValue;
        firstValue = thirdValue;
        thirdValue = temp;

        console.log(firstValue + " " + secondValue + " " + thirdValue);
    }
}