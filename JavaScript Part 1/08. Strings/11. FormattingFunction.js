// Task 11. Write a function that formats a string using placeholders
// The function should work with up to 30 placeholders and all types

function solve() {
    String.format = function() {
        var result = arguments[0];

        for (var i = 0; i < arguments.length - 1; i++) {
            var matchExpression = new RegExp('\\{' + i + '\\}', 'gm');
            result = result.replace(matchExpression, arguments[i + 1]);
        }

        return result;
    };

    var frmt = '{0}, {1}, {0} text {2}';
    var text = String.format(frmt, 1, 'Pesho', 'Gosho');

    console.log(text);
}

solve();