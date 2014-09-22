//////////////////////////////////////////////////////////////////////////////////////////////
// Task 4. Write a script that finds the maximal increasing sequence in an array. Example:  //
// {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.                                                       //
//////////////////////////////////////////////////////////////////////////////////////////////

function solve() {
    var numbersArray = [3, 2, 3, 4, 5, 6, 2, 2, 4];
    var valueCount = 1;
    var maxValueCount = 0;
    var maxValue;

    for (var i = 0; i < numbersArray.length - 1; i++) {
        var valueHolder = numbersArray[i];

        if (valueHolder + 1 === numbersArray[i + 1]) {
            valueCount++;
        } else {
            if (valueCount > maxValueCount) {
                maxValue = valueHolder;
                maxValueCount = valueCount;
            }
            valueCount = 1;
        }
    }

    var output = "<ul>";

    for (var i = maxValueCount - 1; i >= 0; i--) {
        var currentValue = maxValue - i;
        if (i !== 0) {
            output += "<li>" + currentValue + ", " + "</li>";
        } else {
            output += "<li>" + currentValue + "</li>";
        }
    }

    document.getElementById("output").innerHTML = output;

    return false;
}