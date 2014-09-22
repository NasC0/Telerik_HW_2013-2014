var SnakeConfig = (function(Vector, canvasID) {
    var OBJECTS_SIZE = 6;

    var LEFT_ARROW_KEY = 37;
    var UP_ARROW_KEY = 38;
    var RIGHT_ARROW_KEY = 39;
    var DOWN_ARROW_KEY = 40;

    var RIGHT = new Vector(1, 0);
    var DOWN = new Vector(0, 1);
    var LEFT = new Vector(-1, 0);
    var UP = new Vector(0, -1);

    var SNAKE_START_ELEMENTS = 6;
    var CANVAS_LINE_WIDTH = 3;
    var colorIncrementSize = 5;

    var FPS = 5;

    var playerScore = 0;

    var movementVector = RIGHT;

    var directionChangeQueue = [];

    // Used in the keydown event handler 
    // Determines whether the snake has moved this frame
    // and stops direction changes if it has
    var snakeHasMovedThisFrame = false;

    var canvas = document.getElementById(canvasID);
    var canvasContext = canvas.getContext('2d');

    return {
        OBJECTS_SIZE: OBJECTS_SIZE,
        LEFT_ARROW_KEY: LEFT_ARROW_KEY,
        UP_ARROW_KEY: UP_ARROW_KEY,
        RIGHT_ARROW_KEY: RIGHT_ARROW_KEY,
        DOWN_ARROW_KEY: DOWN_ARROW_KEY,
        RIGHT: RIGHT,
        DOWN: DOWN,
        LEFT: LEFT,
        UP: UP,
        SNAKE_START_ELEMENTS: SNAKE_START_ELEMENTS,
        CANVAS_LINE_WIDTH: CANVAS_LINE_WIDTH,
        colorIncrementSize: colorIncrementSize,
        FPS: FPS,
        playerScore: playerScore,
        movementVector: movementVector,
        directionChangeQueue: directionChangeQueue,
        snakeHasMovedThisFrame: snakeHasMovedThisFrame,
        canvas: canvas,
        canvasContext: canvasContext
    };
});