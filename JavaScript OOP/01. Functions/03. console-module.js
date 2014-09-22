////////////////////////////////////////////////////////////
// Task 3.                                                //
// Create a module to work with the console object.       //
// Implement functionality for:                           //
// Writing a line to the console                          //
// Writing a line to the console using a format           //
// Writing to the console should call toString() to each  //
// element                                                //
// Writing errors and warnings to the console with and    //
// without format                                         //
////////////////////////////////////////////////////////////

var specialConsole = (function() {
    function formatString() {
        if (arguments.length > 0) {
            var message = arguments[0];
            for (var i = 0; i < arguments.length - 1; i++) {
                var matchExpression = new RegExp('\\{' + i + '\\}', 'gm');
                message = message.replace(matchExpression, arguments[i + 1].toString());
            }

            return message;
        }
    }

    function writeLine(message) {
        if (arguments.length > 1) {
            message = formatString.apply(null, arguments);
        }

        console.log(message);
    }

    function writeError(message) {
        if (arguments.length > 1) {
            message = formatString.apply(null, arguments);
        }

        console.error(message);
    }

    function writeWarning(message) {
        if (arguments.length > 1) {
            message = formatString.apply(null, arguments);
        }

        console.warn(message);
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };
}());