// BgCoder - 100/100

function Solve(args) {
    var length = parseInt(args[0]);

    var sequencesCount = 0;
    for (var i = 2; i <= length; i++) {
        var currentNumber = parseInt(args[i]);
        var lastNumber = parseInt(args[i - 1]);
        if (currentNumber < lastNumber) {
            sequencesCount++;
        }
    }

    sequencesCount++;

    return sequencesCount;
}

var ags = ['6', '1', '3', '-5', '8', '7', '-6'];
console.log(Solve(ags));