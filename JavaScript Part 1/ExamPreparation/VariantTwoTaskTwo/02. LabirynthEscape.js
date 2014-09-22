function Solve(args) {

    function buildMatrix(args) {
        var directionMatrix = [];
        for (var i = 2; i < args.length; i++) {
            var currentRow = [];
            for (var p = 0; p < args[i].length; p++) {
                currentRow.push(args[i][p]);
            }

            directionMatrix.push(currentRow);
        }

        var numberMatrix = [];
        var counter = 1;
        for (var i = 0; i < directionMatrix.length; i++) {
            var currentRow = [];

            for (var p = 0; p < directionMatrix[i].length; p++) {
                currentRow.push(counter);
                counter++;
            }

            numberMatrix.push(currentRow);
        }

        return [directionMatrix, numberMatrix];
    }

    var matrices = buildMatrix(args);
    var directionMatrix = matrices[0];
    var numericMatrix = matrices[1];
    var start = args[1].split(' ');
    var currentRow = parseInt(start[0]);
    var currentCol = parseInt(start[1]);
    var sum = numericMatrix[currentRow][currentCol];
    var visitedCells = 0;

    while (true) {
        var lastCol = currentCol;
        var lastRow = currentRow;

        switch (directionMatrix[currentRow][currentCol]) {
            case 'l':
                currentCol--;
                break;
            case 'r':
                currentCol++;
                break;
            case 'u':
                currentRow--;
                break;
            case 'd':
                currentRow++;
                break;
            case 'v':
                return 'lost ' + visitedCells;
        }

        directionMatrix[lastRow][lastCol] = 'v';

        if (directionMatrix[currentRow] === undefined || directionMatrix[currentRow][currentCol] === undefined) {
            return 'out ' + sum;
        }

        sum += numericMatrix[currentRow][currentCol];
        visitedCells++;
    }
}

args = [
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "durlddud",
    "urrrldud",
    "ulllllll"
];

console.log(Solve(args));