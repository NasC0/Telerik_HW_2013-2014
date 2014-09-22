////////////////////////////////////////////////////////////////
// Task 2. Create a module that works with moving div nodes.  //
// Implement functionality for:                               //
// Add new moving div element to the DOM                      //
// The module should generate random background, font and     //
// border colors for the div element                          //
// All the div elements are with the same width and height    //
// The movements of the div nodes can be either circular or   //
// rectangular                                                //
// The elements should be moving all the time                 //
////////////////////////////////////////////////////////////////

// WARNING - it seems kind of slow in Chrome. It may take some time to load.
// However it runs just fine in Firefox.

var movingDivs = (function() {
    var WIDTH = '20px';
    var HEIGHT = '20px';
    var rectangularMovement = [];
    var elipseMovement = [];
    var currentSelector;
    var isMoving = false;
    var center;
    var startAngle = 0;
    var containerWidth;
    var containerHeight;

    var directionAndVelocity = {
        right: {
            x: 5,
            y: 0
        },
        up: {
            x: 0,
            y: -5
        },
        left: {
            x: -5,
            y: 0
        },
        down: {
            x: 0,
            y: 5
        }
    };

    function setSelector(selector) {
        currentSelector = document.querySelector(selector);
        containerWidth = parseInt(currentSelector.style.width);
        containerHeight = parseInt(currentSelector.style.height);
        updateCenter();
}
    function updateCenter() {
        center = {
            x: containerWidth / 2,
            y: containerHeight / 2,
            radius: containerWidth > containerHeight ? containerHeight / 2 - parseInt(HEIGHT) : containerWidth / 2 - parseInt(WIDTH)
        };
    }
    function moveDivCircular(center, angle) {
        var position = {
            x: center.x + center.radius * Math.cos(angle),
            y: center.y + center.radius * Math.sin(angle)
        };

        return position;
    }

    String.format = function() {
        var result = arguments[0];

        for (var i = 0; i < arguments.length - 1; i++) {
            var matchExpression = new RegExp('\\{' + i + '\\}', 'gm');
            result = result.replace(matchExpression, arguments[i + 1]);
        }

        return result;
    };

    function getRandomColor() {
        var colorR = getRandomValue(0, 255);
        var colorG = getRandomValue(0, 255);
        var colorB = getRandomValue(0, 255);

        return String.format('rgb({0}, {1}, {2})', colorR, colorG, colorB);
    }

    function getRandomValue(min, max) {
        var randomValue = Math.floor(Math.random() * (max - min) + min);

        return randomValue;
    }

    function generateDiv() {
        var generatedDiv = document.createElement('div');
        var fontColor = getRandomColor();
        var borderColor = getRandomColor();
        var backgroundColor = getRandomColor();
        var borderSize = Math.floor(Math.random() * 10) + 1;

        generatedDiv.style.width = WIDTH;
        generatedDiv.style.height = HEIGHT;
        generatedDiv.style.border = borderSize + 'px solid ' + borderColor;
        generatedDiv.style.backgroundColor = backgroundColor;
        generatedDiv.style.color = fontColor;
        generatedDiv.style.position = 'absolute';

        generatedDiv.innerHTML = 'div';

        return generatedDiv;
    }

    function getRandomDivPosition() {
        var maxWidth = containerWidth;
        var position = Math.floor(Math.random() * maxWidth);

        return position;
    }

    function moveRectangularDivs() {
        var documentFragment = document.createDocumentFragment();

        for (var i = 0; i < rectangularMovement.length; i++) {
            var currentDivObject = rectangularMovement[i];
            var currentDivPosX = parseInt(currentDivObject.div.style.left);
            var currentDivPosY = parseInt(currentDivObject.div.style.top);
            var nextDirection = currentDivObject.direction;

            currentDivPosX += currentDivObject.direction.x;
            currentDivPosY += currentDivObject.direction.y;

            if (currentDivPosX >= containerWidth && currentDivPosY <= 0) {
                nextDirection = directionAndVelocity.down;
            } else if (currentDivPosX <= 0 && currentDivPosY >= containerHeight) {
                nextDirection = directionAndVelocity.up;
            } else if (currentDivPosX >= containerWidth && currentDivPosY >= containerHeight) {
                nextDirection = directionAndVelocity.left;
            } else if (currentDivPosX <= 0 && currentDivPosY <= 0) {
                nextDirection = directionAndVelocity.right;
            }

            currentDivObject.direction = nextDirection;
            currentDivObject.div.style.left = currentDivPosX + 'px';
            currentDivObject.div.style.top = currentDivPosY + 'px';

            documentFragment.appendChild(currentDivObject.div);
        }

        return documentFragment;
    }

    function moveDivs() {
        var ellipseDocFragment = document.createDocumentFragment();
        var rectangleDocFragment;

        startAngle += 0.02;
        while (currentSelector.lastChild) {
            currentSelector.removeChild(currentSelector.lastChild);
        }

        for (var i = 0; i < elipseMovement.length; i++) {
            var currentDiv = elipseMovement[i];
            var currentAngle = startAngle + i * 2 * Math.PI / elipseMovement.length;
            var currentDivPosition = moveDivCircular(center, currentAngle);
            currentDiv.style.left = currentDivPosition.x + 'px';
            currentDiv.style.top = currentDivPosition.y + 'px';

            ellipseDocFragment.appendChild(currentDiv);
        }

        rectangleDocFragment = moveRectangularDivs();

        currentSelector.appendChild(ellipseDocFragment);
        currentSelector.appendChild(rectangleDocFragment);

        setTimeout(function() {
            moveDivs();
        }, 10);
    }

    function add(type) {
        var divToAdd = generateDiv();

        if (type === 'rect') {
            var topPosition = getRandomDivPosition();
            divToAdd.style.left = topPosition + 'px';
            divToAdd.style.top = 0;

            var divObject = {
                div: divToAdd,
                direction: directionAndVelocity.right
            };

            rectangularMovement.push(divObject);
        } else if (type === 'ellipse') {
            elipseMovement.push(divToAdd);
        }

        if (!isMoving) {
            isMoving = true;
            moveDivs();
        }
    }

    return {
        add: add,
        setSelector: setSelector
    };
}());