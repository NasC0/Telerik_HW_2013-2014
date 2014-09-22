String.format = function() {
    var result = arguments[0];

    for (var i = 0; i < arguments.length - 1; i++) {
        var matchExpression = new RegExp('\\{' + i + '\\}', 'gm');
        result = result.replace(matchExpression, arguments[i + 1]);
    }

    return result;
};

var CIRCLE_RADIUS = 0.5;

var paper = Raphael('svg-container', document.innerWidth, document.innerHeight);
var paperMiddleX = paper.width / 2;
var paperMiddleY = paper.height / 2;

var a = 1;
var b = 2.2;

function spiralWithPath() {
    paper.clear();
    var pathString = '';

    for (var i = 0; i < 720; i += 0.1) {
        var angle = 0.1 * i;

        var circleXPosition = paperMiddleX + (a + b * angle) * Math.cos(angle);
        var circleYPosition = paperMiddleY + (a + b * angle) * Math.sin(angle);

        if (i === 0) {
            pathString = String.format('M {0} {1}', circleXPosition, circleYPosition);
            continue;
        }

        pathString += String.format('L {0} {1}', circleXPosition, circleYPosition);
    }

    var path = paper.path(pathString);
}

function spiralWithDots() {
    paper.clear();
    for (var i = 0; i < 720; i += 0.1) {
        var angle = 0.1 * i;

        var circleXPosition = paperMiddleX + (a + b * angle) * Math.cos(angle);
        var circleYPosition = paperMiddleY + (a + b * angle) * Math.sin(angle);

        var currentCircle = paper.circle(circleXPosition, circleYPosition, CIRCLE_RADIUS);
    }
}