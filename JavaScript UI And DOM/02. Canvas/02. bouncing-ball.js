/////////////////////////////////////////////////////////
// Task 2. Draw a circle that flies inside a box       //
// When it reaches an edge, it should bounce that edge //
/////////////////////////////////////////////////////////

window.onload = function() {
    // Ball and collision size
    var BALL_SIZE = 10;
    var COLLISION_SIZE = BALL_SIZE - 1;

    // Colors increment size
    var incrementSize = 5;

    String.format = function() {
        var result = arguments[0];

        for (var i = 0; i < arguments.length - 1; i++) {
            var matchExpression = new RegExp('\\{' + i + '\\}', 'gm');
            result = result.replace(matchExpression, arguments[i + 1]);
        }

        return result;
    };

    // Ensures the ball color being random
    // Picks a RGB color at random and increments it
    // If the color is outside it's range (0 - 255)
    // incrementation size is reversed for ALL colors
    function updateColor(rgbColors) {
        var colorToIncrement = Math.floor(Math.random() * 2);

        if (rgbColors[colorToIncrement] >= 255) {
            incrementSize = -5;
        }

        if (rgbColors[colorToIncrement] <= 0) {
            incrementSize = 5;
        }

        rgbColors[colorToIncrement] += incrementSize;

        return String.format('rgb({0},{1},{2})', rgbColors[0], rgbColors[1], rgbColors[2]);
    }

    function Vector(x, y) {
        this.xDirection = x;
        this.yDirection = y;
    }

    var canvas = document.getElementById('the-canvas');
    var canvasContext = canvas.getContext('2d');

    var directionVector = new Vector(1, 1);
    var currentPositionX = 50;
    var currentPositionY = 50;
    var speed = 5;

    function updatePosition() {
        currentPositionX += speed * directionVector.xDirection;
        currentPositionY += speed * directionVector.yDirection;
    }

    var rgbColors = [0, 0, 0];
    var strokeColor = String.format('rgb({0},{1},{2})', rgbColors[0], rgbColors[1], rgbColors[2]);
    canvasContext.lineWidth = 1;

    function animationFrame(clearScreen) {
        if (clearScreen === true) {
            canvasContext.clearRect(0, 0, canvas.width, canvas.height);
        }

        strokeColor = updateColor(rgbColors);
        canvasContext.fillStyle = strokeColor;

        canvasContext.beginPath();
        canvasContext.arc(currentPositionX, currentPositionY, BALL_SIZE, 0, 2 * Math.PI);
        canvasContext.fill();
        canvasContext.stroke();

        if (currentPositionY <= COLLISION_SIZE || currentPositionY >= canvas.height - COLLISION_SIZE) {
            directionVector.yDirection *= -1;
        }

        if (currentPositionX <= COLLISION_SIZE || currentPositionX >= canvas.width - COLLISION_SIZE) {
            directionVector.xDirection *= -1;
        }

        updatePosition();

        requestAnimationFrame(function() {
            animationFrame(clearScreen);
        });
    }

    // Determines whether the screen will be cleared after every iteration
    var clearScreen = true;
    animationFrame(clearScreen);
};