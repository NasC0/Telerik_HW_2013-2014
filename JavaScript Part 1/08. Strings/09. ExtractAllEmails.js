// Task 9. Write a function for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> should 
// be recognized as emails. Return the emails as array of strings. 

function solve() {

    function extractEmails(text) {
        var emails = [];
        var matches = text.match(/([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi);
        for (var i in matches) {
            emails.push(matches[i]);
        }

        return emails;
    }

    var text = document.getElementById('input').value;
    var emails = extractEmails(text);

    var output = '<p>Extracted emails: </p><ul>';

    for (var i in emails) {
        output += '<li>' + emails[i] + '</li>';
    }

    output += '</ul>';

    document.getElementById('output').innerHTML = output;
    return false;
}