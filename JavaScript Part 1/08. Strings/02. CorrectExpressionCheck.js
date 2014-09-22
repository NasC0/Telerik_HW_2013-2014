// Task 2. Write a JavaScript function to check if in a given expression the brackets are put correctly. 
// Example of correct expression: ((a+b)/5-d). 
// Example of incorrect expression: )(a+b)).

function solve() {

    function checkExpression(expression) {
        var bracketsCount = 0;

        for (var i = 0; i < expression.length; i++) {
            if (expression[i] === ')' && bracketsCount === 0) {
                return false;
            } else if (expression[i] === '(') {
                bracketsCount++;
            } else if (expression[i] === ')') {
                bracketsCount--;
            }
        }

        if (bracketsCount !== 0) {
            return false;
        }

        return true;
    }

    var expressionToCheck = document.getElementById('input').value;
    var isCorrect = checkExpression(expressionToCheck);

    var output = '<p>The expression is correct: ' + isCorrect + '</p>';
    document.getElementById('output').innerHTML = output;

    return false;
}