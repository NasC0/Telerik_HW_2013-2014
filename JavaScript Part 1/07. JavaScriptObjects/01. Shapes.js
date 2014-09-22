//////////////////////////////////////////////////////////////////////////////////////////
// Task 1. Write functions for working with shapes in standard Planar coordinate system //
// Points are represented by coordinates P(X, Y)                                        //
// Lines are represented by two points, marking their beginning and ending              //
// L(P1(X1,Y1), P2(X2,Y2))                                                              //
// Calculate the distance between two points                                            //
// Check if three segment lines can form a triangle                                     //
//////////////////////////////////////////////////////////////////////////////////////////

function solve() {

    function Point(xCoord, yCoord) {
        this.xCoord = xCoord;
        this.yCoord = yCoord;
    }

    function Line(point) {
        this.point = point;
    }

    function calculateDistanceBetweenPoints(firstPoint, secondPoint) {
        var xPoints = (secondPoint.xCoord - firstPoint.xCoord) * (secondPoint.xCoord - firstPoint.xCoord);
        var yPoint = (secondPoint.yCoord - firstPoint.yCoord) * (secondPoint.yCoord - firstPoint.yCoord);
        var distance = Math.sqrt(xPoints + yPoint);

        return distance;
    }

    function canFormTriangle(firstLine, secondLine, thirdLine) {
        var distanceArray = [calculateDistanceBetweenPoints(firstLine.point),
            calculateDistanceBetweenPoints(secondLine.point),
            calculateDistanceBetweenPoints(thirdLine.point)
        ];

        var maxDistance = Math.max.apply(Math, distanceArray);
        var remainingDistance = 0;
        for (var i in distanceArray) {
            if (distanceArray[i] !== maxDistance) {
                remainingDistance += distanceArray[i];
            }
        }

        if (maxDistance > remainingDistance) {
            return false;
        } else {
            return true;
        }
    }

    var firstPoint = new Point(5, 10);
    var secondPoint = new Point(3, 6);

    var distance = calculateDistanceBetweenPoints(firstPoint, secondPoint);

    console.log('The distance between the two points is: ' + distance.toFixed(2));
}

solve();