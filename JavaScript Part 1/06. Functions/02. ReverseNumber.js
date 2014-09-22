/////////////////////////////////////////////////////////////////////////////////
// Task 2. Write a function that reverses the digits of given decimal number.  //
// Example: 256  652                                                          //
/////////////////////////////////////////////////////////////////////////////////

function reverseNumber(number) {
    if (typeof number === 'string') {
        var numberReversed = '';

        for (var i = number.length - 1; i >= 0; i--) {
            numberReversed += number[i];
        }

        return numberReversed;
    }
}

function solve() {
    var number = document.getElementById("input").value;
    var numberReversed = reverseNumber(number);

    var output = "<p>" + number + " reversed is: " + numberReversed + "</p>";

    document.getElementById("output").innerHTML = output;

    return false;
}