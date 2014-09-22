// BgCoder - 100/100

function Solve(args) {
    function buildMatrix(args) {
        var parsedParameters = args[0].split(' ');
        var rows = parseInt(parsedParameters[0]);
        var cols = parseInt(parsedParameters[1]);

        var matrix = [];
        var counter = 1;
        for (var row = 0; row < rows; row++) {
            var currentRow = [];
            for (var col = 0; col < cols; col++) {
                currentRow.push(counter);
                counter++;
            }

            matrix.push(currentRow);
        }

        return matrix;
    }

    var matrix = buildMatrix(args);
    var startParameters = args[1].split(' ');
    var startRow = parseInt(startParameters[0]);
    var startCol = parseInt(startParameters[1]);
    var sum = 0;
    var numberOfJumps = 0;
    var counter = 2;

    while (true) {
        var lastRow = startRow;
        var lastCol = startCol;

        var positionModifiers = args[counter].split(' ');
        startRow += parseInt(positionModifiers[0]);
        startCol += parseInt(positionModifiers[1]);

        if (matrix[lastRow] === undefined || matrix[lastRow][lastCol] === undefined) {
            return 'escaped ' + sum;
        } else if (matrix[lastRow][lastCol] === 'v') {
            return 'caught ' + numberOfJumps;
        }

        sum += matrix[lastRow][lastCol];
        numberOfJumps++;
        matrix[lastRow][lastCol] = 'v';
        counter++;
        if (counter === args.length) {
            counter = 2;
        }
    }
}

var args = [
    '500 500 1',
    '0 0',
    '1 1'
];

console.log(Solve(args));