// Task 5. Write a function that replaces non breaking whitespaces in a text with &nbsp;

function solve() {
    var text = document.getElementById('input').value;
    var regex = new RegExp(' ', 'g');

    text = text.replace(regex, '&nbsp;');

    document.getElementById('output').innerHTML = text;

    return false;
}