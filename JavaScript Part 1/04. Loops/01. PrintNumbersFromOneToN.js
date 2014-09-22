/////////////////////////////////////////////////////////////////////
// Task 1. Write a script that prints all the numbers from 1 to N  //
/////////////////////////////////////////////////////////////////////

function solve() {
    var rawInput = document.getElementById("input").value;
    var n = parseInt(rawInput);
    var outputArray = Array();
    outputArray.push("<ul>");

    for (var i = 0; i < n; i++) {
        outputArray.push("<li>" + i + "</li>");
        console.log(outputArray[i]);
    }

    outputArray.push("</ul>");

    document.getElementById("output").innerHTML = outputArray;

    // returns false so the page doesn't reload after submit button clicked
    return false;
}