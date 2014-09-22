// BgCoder - 86/100

function Solve(args) {

    function getInnerExpression(expression) {
        var innerExpresionMatches = getInnerExpressionString(expression);
        var innerExpression = innerExpresionMatches[0];

        if (innerExpression === undefined) {
            return -1;
        } else {
            return [innerExpression, innerExpresionMatches[1]];
        }
    }

    function getInnerExpressionString(expression) {
        var startOfInnerExpression = expression.indexOf('(') + 1;
        var endOfInnerExpression = expression.indexOf(')');
        var innerExpression;
        var fullInnerExpression;

        if (startOfInnerExpression !== -1 && endOfInnerExpression !== -1) {
            innerExpression = expression.substring(startOfInnerExpression, endOfInnerExpression);
            fullInnerExpression = expression.substring(startOfInnerExpression - 1, endOfInnerExpression + 1);
        }

        return [innerExpression, fullInnerExpression];
    }

    function getInnerExpressionResult(innerExpression) {
        var innerExpressionSplit = splitExpression(innerExpression);
        var operator = innerExpressionSplit[0];
        var result = parseInt(innerExpressionSplit[1]);
        if (isNaN(result)) {
            result = variables[innerExpressionSplit[1]];
        }

        for (var i = 2; i < innerExpressionSplit.length; i++) {
            var secondVariable = parseInt(innerExpressionSplit[i]);

            if (isNaN(secondVariable)) {
                secondVariable = variables[innerExpressionSplit[i]];
            }

            result = calculateOperation(result, secondVariable, operator);
        }

        return result;
    }

    function splitExpression(expression) {
        var expressionDuplicate = expression.trim();
        expressionDuplicate = expression.split(',').join(' ');
        var variables = [];
        var currentString = '';

        for (var i = 0; i < expressionDuplicate.length; i++) {
            if (expressionDuplicate[i] !== ' ') {
                currentString += expressionDuplicate[i];
                if ((expressionDuplicate[i + 1] === ' ' || expressionDuplicate[i + 1] === undefined) &&
                    currentString.length > 0) {
                    variables.push(currentString);
                    currentString = '';
                }
            }
        }

        return variables;
    }

    function calculateOperation(firstNumber, secondNumber, sign) {
        switch (sign) {
            case '+':
                return firstNumber + secondNumber;
            case '-':
                return firstNumber - secondNumber;
            case '*':
                return firstNumber * secondNumber;
            case '/':
                return firstNumber / secondNumber;
        }
    }

    var variables = {};
    var result;
    for (var i = 0; i < args.length; i++) {
        var currentLine = args[i].replace('(', '').replace(')', '');
        var innerExpressionMatches = getInnerExpression(currentLine);
        var innerExpressionResult;

        if (innerExpressionMatches !== -1) {
            var innerExpression = innerExpressionMatches[0];
            currentLine = currentLine.replace(innerExpressionMatches[1], '');

            innerExpressionResult = getInnerExpressionResult(innerExpression);
            if (innerExpressionResult === Number.NEGATIVE_INFINITY || innerExpressionResult === Number.POSITIVE_INFINITY) {
                var line = i + 1;
                return 'Division by zero! At Line:' + line;
            }
        }

        var outerExpressionMatches = splitExpression(currentLine);
        if (outerExpressionMatches[0] !== 'def') {
            var sign = outerExpressionMatches[0];
            result = parseInt(outerExpressionMatches[1]);

            if (isNaN(outerExpressionMatches[1])) {
                result = variables[outerExpressionMatches[1]];
            }

            for (var p = 2; p < outerExpressionMatches.length; p++) {
                var currentVariable = parseInt(outerExpressionMatches[p]);

                if (isNaN(outerExpressionMatches[p])) {
                    currentVariable = variables[outerExpressionMatches[p]];
                }

                result = calculateOperation(result, currentVariable, sign);
            }

            if (innerExpressionMatches !== -1) {
                result = calculateOperation(result, innerExpressionResult, sign);
            }
        } else {
            var variableName = outerExpressionMatches[1];
            var variableValue;
            if (innerExpressionResult !== undefined) {
                variableValue = innerExpressionResult;
            } else {
                variableValue = parseInt(outerExpressionMatches[2]);
            }

            variables[variableName] = variableValue;
        }
    }

    return result;
}

var args = ['(def func 10)', '(def newFunc (+  func 2))', '(def sumFunc (+ func func newFunc 0 0 0))', '(* sumFunc 2)'];
console.log(Solve(args));