function Solve(params) {
    var arrayLength = parseInt(params[0]);
    var currentSum = -2000000;
    var maxSum = -2000000;

    for (var i = 0; i < arrayLength; i++) {
        currentSum += params[i];

        if (currentSum < params[i]) {
            currentSum = params[i];
        }

        if (maxSum < currentSum) {
            maxSum = currentSum;
        }
    }

    return maxSum;
}