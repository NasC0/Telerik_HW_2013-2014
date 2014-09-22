// Task 10. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe". 

function solve() {

    function extractPalindromes(text) {
        var splitWords = text.match(/\w+/g);
        var palindromes = [];

        for (var i = 0; i < splitWords.length; i++) {
            if (splitWords[i].length <= 1) {
                continue;
            }

            if (checkForPalindrome(splitWords[i])) {
                palindromes.push(splitWords[i]);
            }
        }

        return palindromes;
    }

    function checkForPalindrome(word) {
        var isPalindrome = true;
        var loopEnd = parseInt(word.length / 2);

        for (var start = 0, end = word.length - 1; start < loopEnd; start++, end--) {
            if (word[start] !== word[end]) {
                isPalindrome = false;
            }
        }

        return isPalindrome;
    }

    var text = document.getElementById('input').value;
    var palindromes = extractPalindromes(text);

    var output = '<p>Palindromes found: </p><ul>';

    for (var i in palindromes) {
        output += '<li>' + palindromes[i] + '</li>';
    }

    output += '</ul>';
    document.getElementById('output').innerHTML = output;

    return false;
}