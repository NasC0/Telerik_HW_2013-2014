// window.onload = function() {
//     var canvas = document.getElementById('the-canvas');
//     var canvasContext = canvas.getContext('2d');
//     var snakeHeadSprite = document.getElementById('snake-head-left');
//     var snakeHeadOpenSprite = document.getElementById('snake-head-open-right');

//     canvasContext.drawImage(snakeHeadOpenSprite, 50, 50);
// }

//////////////////////////////////////////////////////////////////////////////////////////
// Task 3. *Create the famous game "Snake"                                              //
// The snake is a sequence of rectangles/ellipses                                       //
// The snake can move left, right, up or down                                           //
// The snake dies if it reaches any of the edges or when it tries to eat itself         //
// A food should be generated                                                           //
// When the snake eats the food, it grows and new food is generated at random position  //
// Implement a high-score board, kept in localStorage                                   //
//                                                                                      //
// Sounds taken from http://www.freesound.org/people/PaulMorek/packs/10746/             //
//////////////////////////////////////////////////////////////////////////////////////////

window.onload = function() {
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

    // Used in the keydown event handler 
    // Determines whether the snake has moved this frame
    // and stops direction changes if it has
    var snakeHasMovedThisFrame = false;

    function GameObject(positionX, positionY, radius, startDegrees, endDegrees) {
        this.positionX = positionX;
        this.positionY = positionY;
        this.radius = radius;
        this.startDegrees = startDegrees;
        this.endDegrees = endDegrees;

        this.drawSelf = function(canvasContext, fillObject, strokeColor, fillColor) {
            canvasContext.beginPath();
            canvasContext.arc(this.positionX, this.positionY,
                this.radius, this.startDegrees,
                this.endDegrees);

            canvasContext.strokeStyle = strokeColor || '#000';

            canvasContext.stroke();

            if (fillObject) {
                canvasContext.fillStyle = fillColor;
                canvasContext.fill();
            }

            canvasContext.closePath();
        }
    }

    function Snake() {
        this.body = [];
        this.isHeadOpen = false;

        this.drawSelf = function(canvasContext, movementVector, headSpritesClosed, headSpritesOpen) {
            for (var i = 0; i < this.body.length - 1; i++) {
                this.body[i].drawSelf(canvasContext, true, '#000', 'yellowgreen');
            }

            var lastElement = this.body[this.body.length - 1];
            var drawPositionX = lastElement.positionX - OBJECTS_SIZE - CANVAS_LINE_WIDTH;
            var drawPositionY = lastElement.positionY - OBJECTS_SIZE - CANVAS_LINE_WIDTH;

            var headIndex = '';

            if (movementVector === LEFT) {
                headIndex = 'left';
                drawPositionY -= OBJECTS_SIZE * 2;
                drawPositionX -= OBJECTS_SIZE * 2;
            } else if (movementVector === RIGHT) {
                headIndex = 'right';
                drawPositionY -= OBJECTS_SIZE * 2;
            } else if (movementVector === UP) {
                headIndex = 'up';
                drawPositionX -= OBJECTS_SIZE * 2;
                drawPositionY -= OBJECTS_SIZE * 2;
            } else if (movementVector === DOWN) {
                headIndex = 'down';
            }

            var headToDraw;

            if (this.isHeadOpen) {
                headToDraw = headSpritesOpen[headIndex];
            } else {
                headToDraw = headSpritesClosed[headIndex];
            }

            canvasContext.drawImage(headToDraw, drawPositionX, drawPositionY);
        }
    }

    function Vector(x, y) {
        this.directionX = x;
        this.directionY = y;
    }

    String.format = function() {
        var result = arguments[0];

        for (var i = 0; i < arguments.length - 1; i++) {
            var matchExpression = new RegExp('\\{' + i + '\\}', 'gm');
            result = result.replace(matchExpression, arguments[i + 1]);
        }

        return result;
    };

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

    function initSnake(startingPositionX, startingPositionY) {
        var snake = new Snake();

        for (var i = 0; i < SNAKE_START_ELEMENTS; i++) {
            var currentElementXPosition;

            if (snake.body[snake.body.length - 1] === undefined) {
                currentElementXPosition = startingPositionX;
            } else {
                var lastElement = snake.body[snake.body.length - 1];
                currentElementXPositon = startingPositionX + ((OBJECTS_SIZE * 2) * i);
            }

            var currentSnakeElement = new GameObject(currentElementXPosition, startingPositionY,
                OBJECTS_SIZE, 0, 2 * Math.PI);

            snake.body.push(currentSnakeElement);
        }

        return snake;
    }

    function updateSnakePosition(snake, movementVector) {
        var lastElement = snake.body[snake.body.length - 1];
        snake.body.shift();
        var positionX = lastElement.positionX;
        var positionY = lastElement.positionY;

        if (movementVector.directionX === 1) {
            positionX += OBJECTS_SIZE * 2;
        } else if (movementVector.directionX === -1) {
            positionX -= OBJECTS_SIZE * 2;
        }

        if (movementVector.directionY === 1) {
            positionY += OBJECTS_SIZE * 2;
        } else if (movementVector.directionY === -1) {
            positionY -= OBJECTS_SIZE * 2;
        }

        var newLastElement = new GameObject(positionX, positionY,
            lastElement.radius, lastElement.startDegrees, lastElement.endDegrees);

        snake.body.push(newLastElement);
    }

    function determineCollision(snake) {
        var lastElement = snake.body[snake.body.length - 1];

        if (lastElement.positionX + OBJECTS_SIZE >= canvas.width || lastElement.positionX - OBJECTS_SIZE <= 0) {
            return false;
        }

        if (lastElement.positionY + OBJECTS_SIZE >= canvas.height || lastElement.positionY - OBJECTS_SIZE <= 0) {
            return false;
        }

        var snakeBodyWithoutHead = snake.body.slice(0, snake.body.length - 1);

        for (var i in snakeBodyWithoutHead) {
            var currentElement = snakeBodyWithoutHead[i];
            if (currentElement.positionX === lastElement.positionX &&
                currentElement.positionY === lastElement.positionY) {
                return false;
            }
        }

        return true;
    }

    function generateFood() {
        var foodPositionX = Math.floor(Math.random() * (canvas.width - OBJECTS_SIZE) - CANVAS_LINE_WIDTH);
        var foodPositionY = Math.floor(Math.random() * (canvas.height - OBJECTS_SIZE) - CANVAS_LINE_WIDTH);

        if (foodPositionX <= OBJECTS_SIZE + CANVAS_LINE_WIDTH) {
            while (foodPositionX <= OBJECTS_SIZE + CANVAS_LINE_WIDTH) {
                foodPositionX++;
            }
        }

        if (foodPositionY <= OBJECTS_SIZE + CANVAS_LINE_WIDTH) {
            while (foodPositionY <= OBJECTS_SIZE + CANVAS_LINE_WIDTH) {
                foodPositionY++;
            }
        }

        var food = new GameObject(foodPositionX, foodPositionY,
            OBJECTS_SIZE, 0, 2 * Math.PI);

        return food;
    }

    function incrementSnake(snake) {
        var lastElement = snake.body[0];

        var newElementPositionX = lastElement.positionX;
        var newElementPositionY = lastElement.positionY;

        if (movementVector === LEFT) {
            newElementPositionX += OBJECTS_SIZE * 2;
        }

        if (movementVector === RIGHT) {
            newElementPositionX -= OBJECTS_SIZE * 2;
        }

        if (movementVector === UP) {
            newElementPositionY -= OBJECTS_SIZE * 2;
        }

        if (movementVector === DOWN) {
            newElementPositionY += OBJECTS_SIZE * 2;
        }

        var newElement = new GameObject(newElementPositionX, newElementPositionY,
            OBJECTS_SIZE, 0, 2 * Math.PI);

        snake.body.unshift(newElement);
    }

    function foodEatenCheck(snake, food) {
        var snakeHead = snake.body[snake.body.length - 1];

        if (snakeHead.positionX + OBJECTS_SIZE + CANVAS_LINE_WIDTH >= food.positionX &&
            snakeHead.positionX - (OBJECTS_SIZE + CANVAS_LINE_WIDTH) <= food.positionX &&
            snakeHead.positionY + OBJECTS_SIZE + CANVAS_LINE_WIDTH >= food.positionY &&
            snakeHead.positionY - (OBJECTS_SIZE + CANVAS_LINE_WIDTH) <= food.positionY) {

            return true;
        }
    }

    function endGame(canvasContext) {
        var endGameMessage = 'You scored {0} noms, you fat bastard!';
        canvasContext.fillStyle = 'yellowgreen';
        canvasContext.font = '20px Arial';

        var textWidth = canvasContext.measureText(String.format(endGameMessage, playerScore));
        var textBegin = (canvas.width / 2) - (textWidth.width / 2);
        var textHeight = canvas.height / 2;

        canvasContext.fillText(String.format(endGameMessage, playerScore), textBegin, 100);

        clearInterval(gameLoop);
    }

    var canvas = document.getElementById('the-canvas');
    addEventListener('keydown', doKeyDown, true);

    var canvasContext = canvas.getContext('2d');
    canvasContext.lineWidth = CANVAS_LINE_WIDTH;

    var snakeHeadClosed = {
        'left': document.getElementById('snake-head-left'),
        'right': document.getElementById('snake-head-right'),
        'up': document.getElementById('snake-head-up'),
        'down': document.getElementById('snake-head-down')
    };

    var snakeHeadOpen = {
        'left': document.getElementById('snake-head-open-left'),
        'right': document.getElementById('snake-head-open-right'),
        'up': document.getElementById('snake-head-open-up'),
        'down': document.getElementById('snake-head-open-down')
    };

    var soundFx = document.querySelectorAll('#game-sounds audio');

    function playEatSound() {
        var randomSoundIndex = Math.floor(Math.random() * soundFx.length);

        soundFx[randomSoundIndex].play();
    }

    function doKeyDown(e) {
        if (snakeHasMovedThisFrame) {
            return;
        }

        if (e.keyCode === LEFT_ARROW_KEY && movementVector !== RIGHT) {
            movementVector = LEFT;
        }

        if (e.keyCode === UP_ARROW_KEY && movementVector !== DOWN) {
            movementVector = UP;
        }

        if (e.keyCode === RIGHT_ARROW_KEY && movementVector !== LEFT) {
            movementVector = RIGHT;
        }

        if (e.keyCode === DOWN_ARROW_KEY && movementVector !== UP) {
            movementVector = DOWN;
        }

        snakeHasMovedThisFrame = true;
    }

    var snake = initSnake(50, 50);
    snake.drawSelf(canvasContext, movementVector, snakeHeadClosed, snakeHeadOpen, false);
    var snakeLength = snake.body.length;

    var food = generateFood();

    var foodRGBColors = [0, 0, 0];
    var foodColor = updateColor(foodRGBColors);

    function gameLoop() {
        canvasContext.clearRect(0, 0, canvas.width, canvas.height);

        updateSnakePosition(snake, movementVector);
        snakeHasMovedThisFrame = false;

        var foodIsEaten = foodEatenCheck(snake, food);

        if (foodIsEaten) {
            playerScore += 10;

            food = generateFood();
            incrementSnake(snake);
            snake.isHeadOpen = true;

            playEatSound();

            FPS++;
        }

        snake.drawSelf(canvasContext, movementVector, snakeHeadClosed, snakeHeadOpen, false);
        food.drawSelf(canvasContext, true, '#000', foodColor);

        snake.isHeadOpen = false;

        foodColor = updateColor(foodRGBColors);

        continueLoop = determineCollision(snake);
        if (!continueLoop) {
            endGame(canvasContext);
            return;
        }

        setTimeout(function() {
            requestAnimationFrame(gameLoop);
        }, 1000 / FPS);
    }


    requestAnimationFrame(gameLoop);
}