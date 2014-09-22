//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 7. Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime. //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var number = 37;
var numberSquareRoot = Math.sqrt(number);
var counter = 2;
var isPrime = true;

while (counter <= numberSquareRoot && isPrime) {
    if (number % counter === 0) {
        isPrime = false;
    }
    counter++;
}

console.log(number + " is prime: " + isPrime);