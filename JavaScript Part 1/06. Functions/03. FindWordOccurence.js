///////////////////////////////////////////////////////////////////////////////
// Task 3. Write a function that finds all the occurrences of word in a text //
// The search can case sensitive or case insensitive                         //
// Use function overloading                                                  //
///////////////////////////////////////////////////////////////////////////////

function findOccurrence(text, word, caseSensitive) {
    var regex = '';
    if (caseSensitive) {
        regex = new RegExp("\\b" + word + "\\b", "gi");
    } else {
        regex = new RegExp("\\b" + word + "\\b", "g");
    }

    var occurrences = 0;

    while (regex.exec(text)) {
        occurrences++;
    }

    return occurrences;
}

function solve() {
    var fullText = document.getElementById("fullText").value;
    var wordToSearch = document.getElementById("searchWord").value;
    var caseSensitive = document.getElementById("caseSensitive").checked;

    var wordOccurrences = findOccurrence(fullText, wordToSearch, caseSensitive);

    var output = "<p>The number of occurrences of the word " + wordToSearch + " is: " + wordOccurrences;
    document.getElementById("output").innerHTML = output;

    return false;
}