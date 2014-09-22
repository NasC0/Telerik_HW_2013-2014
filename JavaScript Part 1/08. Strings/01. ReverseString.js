// Task 1. Write a JavaScript function reverses string and returns it 
// Example: "sample"  "elpmas".

function solve() {

    String.prototype.reverse = function() {
        var reversed = [];
        // var result = '';

        for (var i = this.length - 1; i >= 0; i--) {
            reversed.push(this[i]);
        }

        var result = reversed.join('');
        return result;
    }
    var text = document.getElementById("input").value;
    var reversed = text.reverse();

    var output = 'The reversed string is: ' + reversed;
    document.getElementById('output').innerHTML = output;

    return false;
}