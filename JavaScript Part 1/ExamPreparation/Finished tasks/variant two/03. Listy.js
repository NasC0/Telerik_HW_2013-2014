// BgCoder - 75/100

function Solve(args) {
    function getInnerExpression(expression) {
        expression = expression.split(',').join(' ');
        var innerExpression = getInnerExpressionString(expression);

        var innerExpressionParsed = [];

        var expressionSplit = splitExpression(innerExpression);
        for (var i in expressionSplit) {
            var currentVariable = parseInt(expressionSplit[i]);
            if (isNaN(currentVariable)) {
                currentVariable = variables[expressionSplit[i]];
                if (typeof currentVariable !== 'number') {
                    for (var number in currentVariable) {
                        innerExpressionParsed.push(currentVariable[number]);
                    }
                }
            }

            if (typeof currentVariable === 'number') {
                innerExpressionParsed.push(currentVariable);
            }
        }

        return innerExpressionParsed;
    }

    function getInnerExpressionString(expression) {
        var startOfInnerExpression = expression.indexOf('[') + 1;
        var endOfInnerExpression = expression.indexOf(']');

        var innerExpression = expression.substring(startOfInnerExpression, endOfInnerExpression);

        return innerExpression;
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

    function executeSequenceOperation(expression, innerExpressionArray) {
        var operationEnd = expression.indexOf('[');
        var operation = expression.substring(operationEnd - 3, operationEnd);
        var result;

        switch (operation) {
            case 'max':
                result = Math.max.apply(Math, innerExpressionArray);
                break;
            case 'min':
                result = Math.min.apply(Math, innerExpressionArray);
                break;
            case 'avg':
                result = parseInt(getArraySum(innerExpressionArray) / innerExpressionArray.length);
                break;
            case 'sum':
                result = getArraySum(innerExpressionArray);
                break;
        }

        return result;
    }

    function getArraySum(array) {
        var sum = array[0];
        for (var i = 1; i < array.length; i++) {
            sum += array[i];
        }

        return sum;
    }

    var variables = {};

    for (var i = 0; i < args.length - 1; i++) {
        var innerExpression = getInnerExpression(args[i]);
        var currentLine = args[i].trim().substring(args[i].indexOf(' ') + 1).trim();
        var variableName = '';

        if (currentLine.indexOf('sum') !== -1 || currentLine.indexOf('avg') !== -1 ||
            currentLine.indexOf('max') !== -1 || currentLine.indexOf('min') !== -1) {

            variableName = currentLine.substring(0, currentLine.indexOf(' '));
            var operationResult = executeSequenceOperation(currentLine, innerExpression);
            variables[variableName] = operationResult;
        } else {
            currentLine = currentLine.replace(/\s/g, '');
            variableName = currentLine.substring(0, currentLine.indexOf('['));
            variables[variableName] = innerExpression;
        }
    }

    var lastLine = args[args.length - 1].trim();
    var lastLineInnerExpression = getInnerExpression(lastLine);
    if (lastLine.indexOf('[') !== 0) {
        return executeSequenceOperation(lastLine, lastLineInnerExpression);
    } else {
        var returnVariable = lastLineInnerExpression[0];
        var result = parseInt(returnVariable);
        if (isNaN(result)) {
            return variables[result];
        }

        return result;
    }
}

var args = [
    "def maxy max[100   ,600,6001,-100]",
    "def combo [maxy, maxy,maxy,maxy, 5,6]",
    "def summary sum[combo, maxy, -18000]",
    "def pe6o avg[summary,5,maxy]",
    "sum[1, pe6o]"
];

console.log(Solve(args));