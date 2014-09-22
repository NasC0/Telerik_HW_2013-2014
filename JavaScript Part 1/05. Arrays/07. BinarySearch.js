///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 7. Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).  //
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function selectionSort(array) {
    for (var i = 0; i < array.length; i++) {
        var currentValue = i;

        for (var j = i; j < array.length; j++) {
            if (array[j] < array[currentValue]) {
                currentValue = j;
            }
        }

        var temp = array[currentValue];
        array[currentValue] = array[i];
        array[i] = temp;
    }

    return array;
}

function solve() {
    var array = [10, 1, 3, 7, 4, 0, 1, 9, 3, 2, 5, 1];
    var sortedArray = selectionSort(array);

    var searchStart = 0;
    var searchEnd = sortedArray.length - 1;
    var searchMiddle = 0;
    var searchFor = 0;
    var output = '<p>';

    while (searchStart <= searchEnd) {
        searchMiddle = parseInt((searchStart + searchEnd) / 2);

        if (searchFor > sortedArray[searchMiddle]) {
            searchStart = searchMiddle + 1;
        } else if (searchFor < sortedArray[searchMiddle]) {
            searchEnd = searchMiddle - 1;
        } else {
            output = 'Found item ' + searchFor + ' at index ' + searchMiddle + '.</p>';
            break;
        }
    }

    document.getElementById("output").innerHTML = output;

    return false;
}