/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 2. Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time  //
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function solve() {
    var rawInput = document.getElementById("input").value;
    var n = parseInt(rawInput);

    var outputArray = Array();
    outputArray.push("<ul>");

    for (var i = 0; i <= n; i++) {

        if (i % 3 !== 0 || i % 7 !== 0) {
            outputArray.push("<li>" + i + "</li>");
        }

    }

    outputArray.push("</ul>");
    document.getElementById("output").innerHTML = outputArray;

    // returns false so the page doesn't reload after submit button clicked
    return false;
}