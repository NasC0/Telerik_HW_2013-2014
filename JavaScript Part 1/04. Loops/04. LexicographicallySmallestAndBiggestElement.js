/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 4. Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects //
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function solve() {
    var documentArray = Array();
    var navigatorArray = Array();
    var windowArray = Array();

    for (var property in document) {
        documentArray.push(property);
    }

    for (var property in navigator) {
        navigatorArray.push(property);
    }

    for (var property in window) {
        windowArray.push(property);
    }

    documentArray.sort();
    navigatorArray.sort();
    windowArray.sort();

    var output = "<div><p>Min document element: " + documentArray[documentArray.length - 1] + "</p><p>Max document element: " + documentArray[0] + "</p></div>";
    output += "<div><p>Min navigator element: " + navigatorArray[navigatorArray.length - 1] + "</p><p>Max navigator element: " + navigatorArray[0] + "</p></div>";
    output += "<div><p>Min window element: " + windowArray[windowArray.length - 1] + "</p><p>Max window element: " + windowArray[0] + "</p></div>";

    document.getElementById("output").innerHTML = output;

    return false;
}