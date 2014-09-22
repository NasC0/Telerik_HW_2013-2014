///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 4. Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true. //
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var number = 751;

if (number < 100) {
    console.log(number + " does not have 3 digits.");
} else {
    for (var i = 0; i < 2; i++) {
        number = parseInt(number / 10);
    }

    var isSeven = number % 10 === 7;

    console.log(isSeven ? console.log("The third digit is 7.") : console.log("The third digit is not 7."));
}	