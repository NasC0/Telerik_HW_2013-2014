//////////////////////////////////////////////////////////////////////////
// Task 4. Write a function to count the number of divs on the web page //
//////////////////////////////////////////////////////////////////////////

function countDivs() {
    var divOccurrence = document.getElementsByTagName("div");
    return divOccurrence.length;
}

function solve() {
    var divOccurrence = countDivs();

    var output = "<p>Number of divs on the page: " + divOccurrence;
    document.getElementById("output").innerHTML = output;

    return false;
}