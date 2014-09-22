/////////////////////////////////////////////////////////////////////////////////////////////////
// Task 2. Write a script that compares two char arrays lexicographically (letter by letter).  //
/////////////////////////////////////////////////////////////////////////////////////////////////

function solve() {
    var firstInput = document.getElementById("firstInput").value;
    var secondInput = document.getElementById("secondInput").value;

    var output = "<div>";

    if (firstInput.length !== secondInput.length) {
        document.getElementById("output").innerHTML = "<p>The two character arrays mus be the same size!</p>";
    } else {
        for (var i = 0; i < firstInput.length; i++) {
            if (firstInput[i] > secondInput[i]) {
                output += "<p>" + firstInput[i] + " is bigger than " + secondInput[i] + "</p>";
            } else if (firstInput[i] === secondInput[i]) {
                output += "<p>" + secondInput[i] + " is equal to " + firstInput[i] + "</p>";
            } else {
                output += "<p>" + secondInput[i] + " is bigger than " + firstInput[i] + "</p>";
            }
        }
    }

    document.getElementById("output").innerHTML = output + "</div>";

    return false;
}