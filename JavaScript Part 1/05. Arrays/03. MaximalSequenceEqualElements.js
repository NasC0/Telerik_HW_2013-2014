////////////////////////////////////////////////////////////////////////////////////////////
// Task 3. Write a script that finds the maximal sequence of equal elements in an array.  //
// Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.                                   //
////////////////////////////////////////////////////////////////////////////////////////////

function solve() {
    var numbersArray = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];
    var valueCount = 1;
    var maxValueCount = 0;
    var maxValue;

    for (var i = 0; i < numbersArray.length - 1; i++) {
        var valueHolder = numbersArray[i];

        if (valueHolder === numbersArray[i + 1]) {
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

    for (var i = 0; i < maxValueCount; i++) {
        if (i !== maxValueCount - 1) {
            output += "<li>" + maxValue + ", " + "</li>";
        } else {
            output += "<li>" + maxValue + "</li>";
        }
    }

    document.getElementById("output").innerHTML = output;

    return false;
}