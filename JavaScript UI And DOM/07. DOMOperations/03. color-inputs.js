/////////////////////////////////////////////////////////////////////////////////
// Task 3. Create a text area and two inputs with type="color"                 //
// Make the font color of the text area as the value of the first color input  //
// Make the background color of the text area as the value of the second input //
/////////////////////////////////////////////////////////////////////////////////


window.onload = function() {
    var textareaElement = document.getElementById('the-textarea');

    var fontColorInput = document.getElementById('textarea-font-color')
    var backgroundColorInput = document.getElementById('textarea-background-color')

    fontColorInput.addEventListener('change', function() {
        var color = fontColorInput.value;
        textareaElement.style.color = color;
    });

    backgroundColorInput.addEventListener('change', function() {
        var color = backgroundColorInput.value;
        textareaElement.style.backgroundColor = color;
    });
};