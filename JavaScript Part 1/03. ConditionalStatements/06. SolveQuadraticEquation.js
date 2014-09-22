////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 6. Write a script that enters the coefficients a, b and c of a quadratic equation                 //
// a*x2 + b*x + c = 0                                                                                     //
// and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots. //
////////////////////////////////////////////////////////////////////////////////////////////////////////////

var valA = 2;
var valB = 5;
var valC = 3;

var discriminant = (valB * valB) - (4 * valA * valC);

if (discriminant < 0) {
    console.log("The equation has no real roots!");
} else if (discriminant === 0) {
    var root = -(valB / (2 * valA));
    console.log("The equation has only one real root: " + root);
} else {
    var discriminantSqrt = Math.sqrt(discriminant);
    var firstRoot = (-valB + discriminantSqrt) / (2 * valA);
    var secondRoot = (-valB - discriminantSqrt) / (2 * valA);

    console.log("First root: " + firstRoot);
    console.log("Second root: " + secondRoot);
}