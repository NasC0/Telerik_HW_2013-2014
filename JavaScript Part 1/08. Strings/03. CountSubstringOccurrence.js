// Task 3. Write a JavaScript function that finds how many times a substring is contained in a given text (perform case insensitive search). 

function solve() {

    function countWordOccurrences(text, word) {
        var regex = new RegExp(word, 'gi');

        var occurrences = 0;
        while (regex.exec(text)) {
            occurrences++;
        }

        return occurrences;
    }

    var text = document.getElementById('firstInput').value;
    var word = document.getElementById('secondInput').value;

    var occurrences = countWordOccurrences(text, word);
    var output = '<p>' + word + ' occurrences: ' + occurrences + '</p>';
    document.getElementById('output').innerHTML = output;

    return false;
}