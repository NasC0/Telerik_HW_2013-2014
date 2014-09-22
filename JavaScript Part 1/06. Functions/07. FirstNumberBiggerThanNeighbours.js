/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 7. Write a function that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element. //
//  Use the function from the previous exercise.                                                                                                      //
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

function getFirstNumber(array) {
    for (var i = 0; i < array.length - 1; i++) {
        if (checkNeighbours(array, i)) {
            return i;
        }
    }

    return -1;
}

function solve() {
    var randomArray = generateRandomArray();
    var firstIndex = getFirstNumber(randomArray);

    var output = '<p>The index of the first number bigger than it\'s neighbours is: ' + firstIndex + '</p>';
    document.getElementById("output").innerHTML = output;

    return false;
}