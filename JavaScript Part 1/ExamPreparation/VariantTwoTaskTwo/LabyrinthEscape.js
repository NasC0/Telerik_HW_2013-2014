function Solve(params) {
    var splitMatrixDimensions = params[0].split(" ");
    var rows = parseInt(splitMatrixDimensions[0]);
    var cols = parseInt(splitMatrixDimensions[1]);

    var splitStartPosition = params[1].split(" ");
    var startRow = parseInt(splitStartPosition[0]);
    var startCol = parseInt(splitStartPosition[1]);

    var count = 1;
    var matrix = new Array(rows);

    for (var i = 0; i < rows; i++) {
        matrix[i] = new Array(cols);
        for (var j = 0; j < cols; j++) {
            matrix[i][j] = count++;
        }
    }

    var result = "";
    var sum = 0;
    var cellNumber = 0;

    while (true) {
        if ((startRow >= rows || startRow < 0) || (startCol >= cols || startCol < 0)) {
            result = "out " + sum;
            break;
        } else if (matrix[startRow][startCol] == 0) {
            result = "lost " + cellNumber;
            break;
        }

        sum += matrix[startRow][startCol];
        matrix[startRow][startCol] = 0;
        cellNumber++;

        var direction = params[startRow + 2][startCol];
        var moveDirection = NextPosition(direction);
        startRow += moveDirection[0];
        startCol += moveDirection[1];

    }

    console.log(result);
}

function NextPosition(direction) {
    var result;

    switch (direction) {
        case 'l':
            result = [0, -1];
            break;
        case 'r':
            result = [0, 1];
            break;
        case 'u':
            result = [-1, 0];
            break;
        case 'd':
            result = [1, 0];
            break;
        default:
            break;
    }

    return result;
}