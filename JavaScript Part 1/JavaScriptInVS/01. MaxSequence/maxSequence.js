function Solve(params) {

    function getAllVariables(params) {
        var variablesCount = parseInt(params[0]);
        var variables = {};

        for (var i = 1; i <= variablesCount; i++) {
            var currentLine = params[i];
            var currentVariableSplit = currentLine.split(':');
            var variableName = currentVariableSplit[0];
            var literalsSplit = currentVariableSplit[1].split(',');
            if (literalsSplit.length > 1) {
                var variableParams = [];
                for (var j = 0; j < literalsSplit.length; j++) {
                    variableParams.push(literalsSplit[j]);
                }

                variables[variableName] = variableParams;
            } else {
                variables[variableName] = currentVariableSplit[1];
            }
        }

        return variables;
    }

    function getSections(params) {
        var sectionsStart = parseInt(params[0]) + 2;
        var isInSection = false;
        var sections = {};
        var currentSectionLines = [];
        var currentSectionName = '';

        while (true) {
            var currentLine = params[sectionsStart].trim();
            if (isInSection) {
                if (currentLine === '}') {
                    sections[currentSectionName] = currentSectionLines;
                    currentSectionName = '';
                    currentSectionLines = [];
                    isInSection = false;
                    sectionsStart++;
                    continue;
                }

                currentSectionLines.push(params[sectionsStart]);
                sectionsStart++;
            } else {
                if (params[sectionsStart].indexOf('@section') !== -1) {
                    isInSection = true;
                    currentLine = params[sectionsStart].trim();
                    var variableNameString = currentLine.substring(currentLine.indexOf(' '), currentLine.lastIndexOf(' ')).trim();
                    currentSectionName = variableNameString;
                    sectionsStart++;
                } else {
                    break;
                }
            }
        }

        return [sections, sectionsStart];
    }

    function renderSection(sections, currentLine, output) {
        var variableName = currentLine.substring(currentLine.indexOf('"') + 1, currentLine.lastIndexOf('"'));
        var section = sections[variableName];
        for (var p in section) {
            output.push(section[p]);
        }

        return output;
    }

    function foreachFunction(variables, params, output, paramsIndex) {
        var currentLine = params[paramsIndex];
        var conditionStatement = currentLine.substring(currentLine.indexOf('(') + 1, currentLine.indexOf(')'));
        var variableToLoopOverArray = conditionStatement.split(' ');
        var variableToLoopOver = variableToLoopOverArray[variableToLoopOverArray.length - 1];
        var linesToRepeat = [];
        paramsIndex++;
        currentLine = params[paramsIndex];

        while (currentLine.indexOf('}') === -1) {
            linesToRepeat.push(currentLine);
            paramsIndex++;
            currentLine = params[paramsIndex];
        }

        var variablesArray = variables[variableToLoopOver];

        for (var i = 0; i < variablesArray.length; i++) {
            for (var p = 0; p < linesToRepeat.length; p++) {
                var currentLine = linesToRepeat[p];

                if (currentLine.indexOf('@') === -1) {
                    output.push(currentLine);
                } else {
                    var isDoubleAtts = currentLine.substring(currentLine.indexOf('@'), currentLine.indexOf('@') + 2);
                    if (isDoubleAtts === '@@') {
                        currentLine = currentLine.replace('@@', '@');
                    } else {
                        var startCount = currentLine.indexOf('@');
                        var currentVariableName = '';
                        while (currentLine[startCount] !== '<') {
                            if (currentLine[startCount] === ' ' || currentLine[startCount] === undefined) {
                                break;
                            }

                            currentVariableName += currentLine[startCount];
                            startCount++;
                        }
                        if (variables[currentVariableName] !== undefined) {
                            currentLine = currentLine.replace(currentVariableName, variables[currentVariableName.substring(1)]);
                        } else {
                            currentLine = currentLine.replace(currentVariableName, variablesArray[i]);
                        }

                        output.push(currentLine);
                    }
                }
            }
        }

        return output;
    }

    function parseShaver(variables, sections, params, htmlStart) {
        var output = [];
        var isInBrackets = false;
        var addingCondition = false;

        for (var i = htmlStart; i < params.length; i++) {
            var currentLine = params[i];

            if (isInBrackets) {
                var currentLine = params[i];
                if (currentLine.indexOf('}') > -1) {
                    isInBrackets = false;
                    addingCondition = false;
                    continue;
                }

                if (addingCondition) {
                    if (currentLine.indexOf('@') !== -1) {
                        var isDoubleAts = currentLine.substring(currentLine.indexOf('@'), currentLine.indexOf('@') + 2);
                        if (isDoubleAts === '@@') {
                            currentLine = currentLine.replace('@', '');
                            output.push(currentLine);
                        } else {
                            if (currentLine.indexOf('@renderSection') !== -1) {
                                output = renderSection(sections, currentLine, output);
                            } else {
                                var startCount = currentLine.indexOf('@');
                                var currentVariableName = '';
                                while (currentLine[startCount] !== '<') {
                                    if (currentLine[startCount] === ' ') {
                                        break;
                                    }

                                    currentVariableName += currentLine[startCount];
                                    startCount++;
                                }
                                currentLine = currentLine.replace(currentVariableName, variables[currentVariableName.substr(1)]);

                                output.push(currentLine);
                            }
                        }
                    }
                }

                continue;
            }

            if (currentLine.indexOf('@renderSection') !== -1) {
                output = renderSection(sections, currentLine, output);
            } else if (currentLine.indexOf('@if') !== -1) {
                var conditionName = currentLine.substring(currentLine.indexOf('(') + 1, currentLine.lastIndexOf(')'));
                var condition = variables[conditionName];
                isInBrackets = true;

                if (condition === 'true') {
                    addingCondition = true;
                    addingConditionIndex = i + 1;
                } else {
                    addingCondition = false;
                }
            } else if (currentLine.indexOf('@foreach') !== -1) {
                output = foreachFunction(variables, params, output, i);
            } else if (currentLine.indexOf('@') !== -1) {
                var isDoubleAtts = currentLine.substring(currentLine.indexOf('@'), currentLine.indexOf('@') + 2);
                if (isDoubleAtts === '@@') {
                    currentLine = currentLine.replace('@@', '@');
                    output.push(currentLine);
                } else {
                    var currentVariableName = '';
                    var currentIndex = currentLine.indexOf('@');
                    while (currentLine[currentIndex] !== '<') {
                        if (currentLine[currentIndex] === ' ' || currentLine[currentIndex] === undefined) {
                            break;
                        }

                        currentVariableName += currentLine[currentIndex];
                        currentIndex++;
                    }

                    currentLine = currentLine.replace(currentVariableName, variables[currentVariableName.substring(1)]);

                    output.push(currentLine);
                }
            } else {
                output.push(currentLine);
            }
        }

        return output;
    }

    var variables = getAllVariables(params);
    var sectionsData = getSections(params);
    var sections = sectionsData[0];
    var htmlStart = sectionsData[1];
    var output = parseShaver(variables, sections, params, htmlStart);
    var result = output.join('\n\r');
    return result;
}

var params = [
    "6",
    "title:Telerik Academy ",
    "showSubtitle:true ",
    "subTitle:Free training ",
    "showMarks:false ",
    "marks:3,4,5,6 ",
    "students:Pesho,Gosho,Ivan ",
    "42 ",
    "@section menu { ",
    "<ul id='menu'> ",
    "<li>Home</li> ",
    "<li>About us</li> ",
    "</ul> ",
    "} ",
    "@section footer { ",
    "<footer> ",
    "Copyright Telerik Academy 2014 ",
    "</footer> ",
    "} ",
    "<!DOCTYPE html> ",
    "<html> ",
    "<head> ",
    "<title>Telerik Academy</title> ",
    "</head> ",
    "<body> ",
    '@renderSection("menu") ',

    "<h1>@title</h1> ",
    "@if (showSubtitle) { ",
    "<h2>@subTitle</h2> ",
    "<div>@@JustNormalTextWithDoubleKliomba ;)</div> ",
    "} ",
    "",
    "<ul> ",
    " @foreach (var student in students) { ",
    "<li> ",
    "@student",
    "</li> ",
    "<li>Multiline @title</li> ",
    "} ",
];

console.log(Solve(params));