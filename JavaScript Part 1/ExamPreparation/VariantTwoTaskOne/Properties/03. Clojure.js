// BgCoder - 86/100

function Solve(args) {

    function getInnerExpression(expression) {

        var innerExpressionMatches = expression.match(/\((.*?)\)/);
        var innerExpression;
        if (innerExpressionMatches) {
            innerExpression = innerExpressionMatches[1];
        }

        if (innerExpression === undefined) {
            return -1;
        } else {
            return [innerExpression, innerExpressionMatches[0]];
        }
    }

    function getInnerExpressionResult(innerExpression) {
        var splitExpression = innerExpression.match(/[^ ]+/g);
        var operator = splitExpression[0];
        var result = parseInt(splitExpression[1]);
        if (isNaN(result)) {
            result = variables[splitExpression[1]];
        }

        for (var i = 2; i < splitExpression.length; i++) {
            var secondVariable = parseInt(splitExpression[i]);

            if (isNaN(secondVariable)) {
                secondVariable = variables[splitExpression[i]];
            }

            result = calculateOperation(result, secondVariable, operator);
        }

        return result;
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

        var outerExpressionMatches = currentLine.match(/[^ ]+/g);
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