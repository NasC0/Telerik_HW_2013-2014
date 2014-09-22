/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 5. Sorting an array means to arrange its elements in increasing order. Write a script to sort an array. Use the "selection sort" algorithm: Find the smallest  //
// element, move it at the first position, find the smallest from the rest, move it at the second position, etc.                                                       //
// Hint: Use a second array                                                                                                                                            //
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function solve() {
    var arrayToSort = [4, 1, 5, 10, 7, 7, 3, 6, 4];

    for (var i = 0; i < arrayToSort.length; i++) {
        var currentValue = i;

        for (var j = i; j < arrayToSort.length; j++) {
            if (arrayToSort[j] < arrayToSort[currentValue]) {
                currentValue = j;
            }
        }

        var temp = arrayToSort[currentValue];
        arrayToSort[currentValue] = arrayToSort[i];
        arrayToSort[i] = temp;
    }

    var output = "<ul>";

    for (var i = 0; i < arrayToSort.length; i++) {
        if (i !== arrayToSort.length - 1) {
            output += "<li>" + arrayToSort[i] + ", </li>";
        } else {
            output += "<li>" + arrayToSort[i] + "</li>";
        }
    }

    document.getElementById("output").innerHTML = output;

    return false;
}