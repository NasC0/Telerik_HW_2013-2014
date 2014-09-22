function selectWithQuerySelectorAll() {
    var selectedDivs = document.querySelector('div');
    return selectedDivs;
}

var result = selectWithQuerySelectorAll();

console.log(result);

var newTest = document.querySelectorAll('div');
console.log(newTest);
var canvas = document.getElementById('the-canvas');
var ctx = canvas.getContext('2d');