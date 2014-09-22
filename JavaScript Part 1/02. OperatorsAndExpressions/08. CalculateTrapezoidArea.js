///////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 8. Write an expression that calculates trapezoid's area by given sides a and b and height h. //
///////////////////////////////////////////////////////////////////////////////////////////////////////

/**
 * String.format function taken from http://stackoverflow.com/questions/2534803/string-format-in-javascript.
 * Behaves the same way as .NET's String.Format().
 * @return {[void]} [returns void]
 */
String.format = function() {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }
    return s;
};

var sideA = 5;
var sideB = 5;
var height = 10;

var area = ((sideA + sideB) / 2) * height;

console.log(String.format("Trapezoid area: {0}", area));