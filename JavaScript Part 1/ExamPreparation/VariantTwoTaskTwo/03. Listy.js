function Solve(args) {
    function getInnerExpression(expression) {
        expression = expression.replace(/,/g, ' ');
        var innerExpressionMatches = expression.match(/\[(.*?)\]/);
        var innerExpression;

        if (innerExpressionMatches) {
            innerExpression = innerExpressionMatches[1];
        }

        var innerExpressionParsed = [];

        var splitExpression = innerExpression.match(/[^ ]+/g);
        for (var i in splitExpression) {
            var currentVariable = parseInt(splitExpression[i]);
            if (isNaN(currentVariable)) {
                currentVariable = variables[splitExpression[i]];
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

        if (currentLine.match(/^sum$/) !== -1 || currentLine.match(/^avg$/) !== -1 ||
            currentLine.match(/^max$/) !== -1 || currentLine.match(/^min$/) !== -1) {

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