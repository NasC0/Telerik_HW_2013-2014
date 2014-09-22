function Solve(args) {
    var maxSum = parseInt(args[0]);

    var currentSum = -999999999999;
    for (var i = 1; i < args.length; i++) {
        var currentValue = parseInt(args[i]);
        currentSum += currentValue;

        if (currentValue > currentSum) {
            currentSum = currentValue;
        }

        if (currentSum > maxSum) {
            maxSum = currentSum;

        }
    }

    return maxSum;
}

var args = ['8', '1', '6', '-9', '4', '4', '-2', '10', '-1'];
console.log(Solve(args));