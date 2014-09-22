////////////////////////////////////////////////////////////////////////////////////////
// Task 6. Write a program that finds the most frequent number in an array. Example:  //
// {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)                              //
////////////////////////////////////////////////////////////////////////////////////////

function solve() {
    var numbersArray = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3, 3, 3, 3, 3];
    var currentOccurence = 0;
    var maxOccurence = 0;
    var number = 0;
    var maxNumber = 0;

    for (var i = 0; i < numbersArray.length - 1; i++) {
        number = numbersArray[i];
        currentOccurence = 1;

        for (var j = i + 1; j < numbersArray.length; j++) {
            if (numbersArray[j] === number) {
                currentOccurence++;
            }
        }

        if (currentOccurence > maxOccurence) {
            maxOccurence = currentOccurence;
            maxNumber = number;
        }
    }

    var output = "<p>The most frequent number is: " + maxNumber + " and it's repeated " + maxOccurence + " times.";

    document.getElementById("output").innerHTML = output;

    return false;
}