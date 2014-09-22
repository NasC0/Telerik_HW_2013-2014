///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 9. Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2). //
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var xPoint = 2;
var yPoint = 1;

if (((xPoint - 1) * (xPoint - 1)) + ((yPoint - 1) * (yPoint - 1)) <= 3 * 3) {
    console.log("The point is within the circle");
} else {
    console.log("The point is outside the circle");
}

if ((xPoint >= -1 && xPoint <= 5) && (yPoint >= -1 && yPoint <= 1)) {
    console.log("The point is within the rectangle");
} else {
    console.log("The point is outside the rectangle");
}