//////////////////////////////////////////////////////////////////////////////////////////
// Task 3. Write a script that finds the max and min number from a sequence of numbers. //
//////////////////////////////////////////////////////////////////////////////////////////

// You still have to press submit for the output to show.
function solve() {
    var sequence = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
    var min = 9007199254740992;
    var max = -9007199254740992;

    for (var item in sequence) {

        if (item < min) {
            min = item;
            console.log(min);
        }

        if (item > max) {
            max = item;
            console.log(max);
        }
    }

    var outputArray = [
        "<p>Max item in sequence: " + max + "</p>",
        "<p>Min item in sequence: " + min + "</p>"
    ];

    document.getElementById("output").innerHTML = outputArray;

    return false;
}