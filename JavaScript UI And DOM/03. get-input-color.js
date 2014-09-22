function setBodyColor(color) {
    document.body.style.backgroundColor = color;
}

function getInputColorQuerySelector() {
    var getInput = document.querySelector('input[type=color]');
    var colorValue = getInput.value;

    setBodyColor(colorValue);
}

function getInputColorTagName() {
    var allInputs = document.getElementsByTagName('input');
    var inputsLength = allInputs.length;

    for (var i = 0; i < inputsLength; i++) {
        if (allInputs[i].type === "color") {
            var color = allInputs[i].value;
            setBodyColor(color);

            return;
        }
    }
}