///////////////////////////////////////////////////////////////////////////
// Task 2. Write a function that removes all elements with a given value //
// Attach it to the array type                                           //
///////////////////////////////////////////////////////////////////////////

function solve() {

    Array.prototype.remove = function(element) {
        var result = [];

        for (var i = 0; i < this.length; i++) {
            if (this[i] !== element) {
                result.push(this[i]);
            }
        }

        while (this.length > 0) {
            this.pop();
        }

        var counter = 0;
        while (this.length < result.length) {
            this.push(result[counter]);
            counter++;
        }
    };

    var arr = [1, 2, 3, 4, 5, 6, 1, 1, 1, 1, 'dvesta', 'dvesta'];
    arr.remove(1);
    console.log(arr);
}

solve();