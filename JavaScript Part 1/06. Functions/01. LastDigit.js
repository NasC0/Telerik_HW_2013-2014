//////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 1. Write a function that returns the last digit of given integer as an English word. Examples:  //
// 512  "two", 1024  "four", 12309  "nine"                                                           //
//////////////////////////////////////////////////////////////////////////////////////////////////////////

function getLastDigit(number) {
    if (typeof(number) !== typeof(1)) {
        return -1;
    } else {
        var lastDigit = number % 10;
        switch (lastDigit) {
            case 0:
                return "Zero";
            case 1:
                return "One";
            case 2:
                return "Two";
            case 3:
                return "Three";
            case 4:
                return "Four";
            case 5:
                return "Five";
            case 6:
                return "Six";
            case 7:
                return "Seven";
            case 8:
                return "Eight";
            case 9:
                return "Nine";
        }
    }
}

function solve() {
    var number = parseInt(document.getElementById("input").value);

    var output = "<p>The last digit of " + number + " is: " + getLastDigit(number) + "</p>";

    document.getElementById("output").innerHTML = output;

    return false;
}