///////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 2. Create a function that gets the value of <input type="text"> ands prints its value to the console //
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

function getTextValueQuerySelector() {
    var input = document.querySelector('input[type=text]');

    console.log(input.value);
}

function getTextValueGetElement() {
    var inputTags = document.getElementsByTagName('input');
    var inputTagsLength = inputTags.length;

    for (var i = 0; i < inputTagsLength; i++) {
        if (inputTags[i].type === 'text') {
            console.log(inputTags[i].value);
            return;
        }
    }
}

var canvas = document.getElementById('the-canvas');
var ctx = canvas.getContext('2d');