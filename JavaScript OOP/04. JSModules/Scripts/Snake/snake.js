var Snake = (function(snakeConfig, GameObject) {
    function Snake() {
        this.body = [];
        this.isHeadOpen = false;
    }

    Snake.prototype.drawSelf = function(canvasContext, movementVector, headSpritesClosed, headSpritesOpen) {
        for (var i = 0; i < this.body.length - 1; i++) {
            this.body[i].drawSelf(canvasContext, true, '#000', 'yellowgreen');
        }

        var lastElement = this.body[this.body.length - 1];
        var drawPositionX = lastElement.positionX - snakeConfig.OBJECTS_SIZE - snakeConfig.CANVAS_LINE_WIDTH;
        var drawPositionY = lastElement.positionY - snakeConfig.OBJECTS_SIZE - snakeConfig.CANVAS_LINE_WIDTH;

        var headIndex = '';

        if (movementVector === snakeConfig.LEFT) {
            headIndex = 'left';
            drawPositionY -= snakeConfig.OBJECTS_SIZE * 2;
            drawPositionX -= snakeConfig.OBJECTS_SIZE * 2;
        } else if (movementVector === snakeConfig.RIGHT) {
            headIndex = 'right';
            drawPositionY -= snakeConfig.OBJECTS_SIZE * 2;
        } else if (movementVector === snakeConfig.UP) {
            headIndex = 'up';
            drawPositionX -= snakeConfig.OBJECTS_SIZE * 2;
            drawPositionY -= snakeConfig.OBJECTS_SIZE * 2;
        } else if (movementVector === snakeConfig.DOWN) {
            headIndex = 'down';
        }

        var headToDraw;

        if (this.isHeadOpen) {
            headToDraw = headSpritesOpen[headIndex];
        } else {
            headToDraw = headSpritesClosed[headIndex];
        }

        canvasContext.drawImage(headToDraw, drawPositionX, drawPositionY);
    };

    function initSnake(startingPositionX, startingPositionY) {
        var snake = new Snake();

        for (var i = 0; i < snakeConfig.SNAKE_START_ELEMENTS; i++) {
            var currentElementXPosition;

            if (snake.body[snake.body.length - 1] === undefined) {
                currentElementXPosition = startingPositionX;
            } else {
                var lastElement = snake.body[snake.body.length - 1];
                currentElementXPosition = startingPositionX + ((snakeConfig.OBJECTS_SIZE * 2) * i);
            }

            var currentSnakeElement = new GameObject(currentElementXPosition, startingPositionY,
                snakeConfig.OBJECTS_SIZE, 0, 2 * Math.PI);

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
            positionX += snakeConfig.OBJECTS_SIZE * 2;
        } else if (movementVector.directionX === -1) {
            positionX -= snakeConfig.OBJECTS_SIZE * 2;
        }

        if (movementVector.directionY === 1) {
            positionY += snakeConfig.OBJECTS_SIZE * 2;
        } else if (movementVector.directionY === -1) {
            positionY -= snakeConfig.OBJECTS_SIZE * 2;
        }

        var newLastElement = new GameObject(positionX, positionY,
            lastElement.radius, lastElement.startDegrees, lastElement.endDegrees);

        snake.body.push(newLastElement);
    }


    function incrementSnake(snake) {
        var lastElement = snake.body[0];

        var newElementPositionX = lastElement.positionX;
        var newElementPositionY = lastElement.positionY;

        if (snakeConfig.movementVector === snakeConfig.LEFT) {
            newElementPositionX += snakeConfig.OBJECTS_SIZE * 2;
        }

        if (snakeConfig.movementVector === snakeConfig.RIGHT) {
            newElementPositionX -= snakeConfig.OBJECTS_SIZE * 2;
        }

        if (snakeConfig.movementVector === snakeConfig.UP) {
            newElementPositionY -= snakeConfig.OBJECTS_SIZE * 2;
        }

        if (snakeConfig.movementVector === snakeConfig.DOWN) {
            newElementPositionY += snakeConfig.OBJECTS_SIZE * 2;
        }

        var newElement = new GameObject(newElementPositionX, newElementPositionY,
            snakeConfig.OBJECTS_SIZE, 0, 2 * Math.PI);

        snake.body.unshift(newElement);
    }

    return {
        initSnake: initSnake,
        updateSnakePosition: updateSnakePosition,
        incrementSnake: incrementSnake
    };

}(snakeConfig, GameObjects.GameObject));