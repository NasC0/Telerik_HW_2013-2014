var helpers = (function(SnakeConfig, GameObject) {
    function determineBoundaryCollision(snake) {
        var lastElement = snake.body[snake.body.length - 1];

        if (lastElement.positionX + SnakeConfig.OBJECTS_SIZE >= SnakeConfig.canvas.width || lastElement.positionX - SnakeConfig.OBJECTS_SIZE <= 0) {
            return false;
        }

        if (lastElement.positionY + SnakeConfig.OBJECTS_SIZE >= SnakeConfig.canvas.height || lastElement.positionY - SnakeConfig.OBJECTS_SIZE <= 0) {
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
        var foodPositionX = Math.floor(Math.random() * (SnakeConfig.canvas.width - SnakeConfig.OBJECTS_SIZE) - SnakeConfig.CANVAS_LINE_WIDTH);
        var foodPositionY = Math.floor(Math.random() * (SnakeConfig.canvas.height - SnakeConfig.OBJECTS_SIZE) - SnakeConfig.CANVAS_LINE_WIDTH);

        if (foodPositionX <= SnakeConfig.OBJECTS_SIZE + SnakeConfig.CANVAS_LINE_WIDTH) {
            while (foodPositionX <= SnakeConfig.OBJECTS_SIZE + SnakeConfig.CANVAS_LINE_WIDTH) {
                foodPositionX++;
            }
        }

        if (foodPositionY <= SnakeConfig.OBJECTS_SIZE + SnakeConfig.CANVAS_LINE_WIDTH) {
            while (foodPositionY <= SnakeConfig.OBJECTS_SIZE + SnakeConfig.CANVAS_LINE_WIDTH) {
                foodPositionY++;
            }
        }

        var food = new GameObject(foodPositionX, foodPositionY,
            SnakeConfig.OBJECTS_SIZE, 0, 2 * Math.PI);

        return food;
    }

    function foodEatenCheck(snake, food) {
        var snakeHead = snake.body[snake.body.length - 1];

        var dX = snakeHead.positionX - food.positionX;
        var dY = snakeHead.positionY - food.positionY;

        var distance = Math.sqrt((dX * dX) + (dY * dY));

        if (distance < snakeHead.radius + food.radius) {
            return true;
        }
    }

    function executeDirectionChange() {
        if (SnakeConfig.directionChangeQueue.length > 0) {
            SnakeConfig.movementVector = SnakeConfig.directionChangeQueue.pop();
        }
    }

    function doKeyDown(e) {

        if (e.keyCode === SnakeConfig.LEFT_ARROW_KEY && SnakeConfig.movementVector !== SnakeConfig.RIGHT) {
            SnakeConfig.directionChangeQueue.push(SnakeConfig.LEFT);
        }

        if (e.keyCode === SnakeConfig.UP_ARROW_KEY && SnakeConfig.movementVector !== SnakeConfig.DOWN) {
            SnakeConfig.directionChangeQueue.push(SnakeConfig.UP);
        }

        if (e.keyCode === SnakeConfig.RIGHT_ARROW_KEY && SnakeConfig.movementVector !== SnakeConfig.LEFT) {
            SnakeConfig.directionChangeQueue.push(SnakeConfig.RIGHT);
        }

        if (e.keyCode === SnakeConfig.DOWN_ARROW_KEY && SnakeConfig.movementVector !== SnakeConfig.UP) {
            SnakeConfig.directionChangeQueue.push(SnakeConfig.DOWN);
        }
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
            SnakeConfig.colorIncrementSize = -5;
        }

        if (rgbColors[colorToIncrement] <= 0) {
            SnakeConfig.colorIncrementSize = 5;
        }

        rgbColors[colorToIncrement] += SnakeConfig.colorIncrementSize;

        return String.format('rgb({0},{1},{2})', rgbColors[0], rgbColors[1], rgbColors[2]);
    }

    function playEatSound(soundFxContainer) {
        var randomSoundIndex = Math.floor(Math.random() * soundFxContainer.length);

        soundFxContainer[randomSoundIndex].play();
    }

    return {
        determineBoundaryCollision: determineBoundaryCollision,
        generateFood: generateFood,
        foodEatenCheck: foodEatenCheck,
        executeDirectionChange: executeDirectionChange,
        doKeyDown: doKeyDown,
        updateColor: updateColor,
        playEatSound: playEatSound
    };

}(snakeConfig, GameObjects.GameObject));