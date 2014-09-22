////////////////////////////////////////////////////////////////////////////////////////////////
// Task 6. Write an expression that checks if given print (x,  y) is within a circle K(O, 5). //
////////////////////////////////////////////////////////////////////////////////////////////////

var xPoint = 2;
var yPoint = 1;

var isWithinCircle = ((xPoint - 0) * (xPoint - 0)) + ((yPoint - 0) * (yPoint - 0)) <= 5 * 5;

if (isWithinCircle) {
    console.log("The point is within the circle.");
} else {
    console.log("The point is not within the circle.");
}