//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 6. Write a function that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist). //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function checkNeighbours(array, index) {
    if (index >= array.length) {
        return false;
    } else {
        if (index > 0 && index < array.length - 1 &&
            array[index] > array[index - 1] && array[index] > array[index + 1]) {
            return true;
        } else {
            return false;
        }
    }
}

function generateRandomArray() {
    var MAX_SEED = 100;
    var array = [];
    var randomNumbersCount = Math.floor(Math.random() * MAX_SEED) + 1;

    for (var i = 0; i < randomNumbersCount; i++) {
        array.push(Math.floor(Math.random() * MAX_SEED) + 1);
    }

    return array;
}

function solve() {
    var position = parseInt(document.getElementById("input").value);
    var randomArray = generateRandomArray();

    var result = checkNeighbours(randomArray, position);

    var output = '<p>Element ' + randomArray[position] + ' bigger than neighbours: ';
    if (result === true) {
        output += 'true';
    } else {
        output += 'false';
    }

    output += '</p>';
    document.getElementById("output").innerHTML = output;

    return false;
}