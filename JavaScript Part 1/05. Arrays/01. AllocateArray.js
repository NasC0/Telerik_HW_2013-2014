// Task 1. Write a script that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.

function solve() {
    var numberArray = Array(20);

    var output = "<ul>";

    for (var i = 0; i < numberArray.length; i++) {
        numberArray[i] = i * 5;
        console.log(numberArray[i]);
        output += "<li>" + numberArray[i] + "</li>";
    }

    document.getElementById("output").innerHTML = output;

    return false;
}