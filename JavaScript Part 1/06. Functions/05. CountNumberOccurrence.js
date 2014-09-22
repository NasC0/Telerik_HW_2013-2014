// Task 5. Write a function that counts how many times given number appears in given array. Write a test function to check if the function is working correctly.

function countOccurrence(array, number) {
    var count = 0;

    for (var i = 0; i < array.length; i++) {
        if (array[i] === number) {
            count++;
        }
    }

    return count;
}

//+ Jonas Raoni Soares Silva
//@ http://jsfromhell.com/array/shuffle [v1.0]
// Shuffles given array
// Taken from http://stackoverflow.com/questions/6274339/how-can-i-shuffle-an-array-in-javascript
function shuffle(o) { //v1.0
    for (var j, x, i = o.length; i; j = Math.floor(Math.random() * i), x = o[--i], o[i] = o[j], o[j] = x);
    return o;
}

function testCountOccurrence() {
    var MAX_RANDOM_SEED = 100;

    // Get random number, random count of that number and filler numbers - also random count
    var randomNumberToCheck = Math.floor(Math.random() * MAX_RANDOM_SEED) + 1;
    var randomNumberOccurrence = Math.floor(Math.random() * MAX_RANDOM_SEED) + 1;
    var fillerNumbersCount = Math.floor(Math.random() * MAX_RANDOM_SEED) + 1;
    var array = [];

    // Insert the random number to check for
    for (var i = 0; i < randomNumberOccurrence; i++) {
        array.push(randomNumberToCheck);
    }

    // Insert filler numbers
    var counter = 0;
    while (counter <= fillerNumbersCount) {
        var currentNumber = Math.floor(Math.random() * MAX_RANDOM_SEED) + 1;
        if (currentNumber !== randomNumberToCheck) {
            array.push(currentNumber);
            counter++;
        }
    }

    // Shuffle random array
    array = shuffle(array);

    // Test the countOccurrence function
    var result = countOccurrence(array, randomNumberToCheck);

    var output = "<p>Count occurence for: " + randomNumberToCheck + ". Expected result: " + randomNumberOccurrence + ". Result: " + result + "</p>";

    return output;
}

function solve() {
    var output = testCountOccurrence();
    document.getElementById("output").innerHTML = output;

    return false;
}