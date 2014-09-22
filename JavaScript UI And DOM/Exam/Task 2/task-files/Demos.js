function outer() {
    var outerValue = 5;

    function middle() {
        var middleValue = 10;

        function inner() {
            var innerValue = 15;
            console.log(outerValue);
            console.log(middleValue);
            console.log(innerValue);
        }

        inner();
    }

    middle();
}

outer();