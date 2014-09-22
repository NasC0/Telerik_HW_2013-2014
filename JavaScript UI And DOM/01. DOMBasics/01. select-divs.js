function selectWithQuerySelector() {
    var selectedDivs = document.querySelectorAll('div div');

    var selectedDivsLength = selectedDivs.length;
    var outputDiv = document.querySelector('#output');
    outputDiv.innerHTML = '<p>Divs selected with querySelectorAll count: ' + selectedDivsLength + '</p>';
}

function selectWithGetElementsByTag() {
    var allDivs = document.getElementsByTagName('div');
    var totalDivCount = allDivs.length;
    var selectedDivs = [];

    for (var i = 0; i < totalDivCount; i++) {
        var currentDiv = allDivs[i];

        if (currentDiv.parentElement instanceof HTMLDivElement) {
            selectedDivs.push(currentDiv);
        }
    }

    var selectedDivsLength = selectedDivs.length;
    var outputDiv = document.getElementById('output');
    outputDiv.innerHTML = '<p>Divs selected with getElementById count: ' + selectedDivsLength + '</p>';
}