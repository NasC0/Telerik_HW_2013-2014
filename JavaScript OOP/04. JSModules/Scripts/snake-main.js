(function(GameObjects, SnakeConfig, Snake, helpers) {
    function endGame(canvasContext) {
        var endGameMessage = 'You scored {0} noms, you fat bastard!';
        canvasContext.fillStyle = 'yellowgreen';
        canvasContext.font = '20px Arial';

        var textWidth = canvasContext.measureText(String.format(endGameMessage, SnakeConfig.playerScore));
        var textBegin = (SnakeConfig.canvas.width / 2) - (textWidth.width / 2);
        var textHeight = SnakeConfig.canvas.height / 2;

        canvasContext.fillText(String.format(endGameMessage, SnakeConfig.playerScore), textBegin, 100);

        clearInterval(gameLoop);
    }

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

    addEventListener('keydown', helpers.doKeyDown, false);

    var soundFx = document.querySelectorAll('#game-sounds audio');

    var snake = Snake.initSnake(50, 50);
    snake.drawSelf(SnakeConfig.canvasContext, SnakeConfig.movementVector, snakeHeadClosed, snakeHeadOpen, false);

    var food = helpers.generateFood();

    SnakeConfig.canvasContext.lineWidth = SnakeConfig.CANVAS_LINE_WIDTH;

    var foodRGBColors = [0, 0, 0];
    var foodColor = helpers.updateColor(foodRGBColors);

    function gameLoop() {
        SnakeConfig.canvasContext.clearRect(0, 0, SnakeConfig.canvas.width, SnakeConfig.canvas.height);

        helpers.executeDirectionChange();
        Snake.updateSnakePosition(snake, SnakeConfig.movementVector);
        SnakeConfig.snakeHasMovedThisFrame = false;

        var foodIsEaten = helpers.foodEatenCheck(snake, food);

        if (foodIsEaten) {
            SnakeConfig.playerScore += 10;

            food = helpers.generateFood();
            Snake.incrementSnake(snake);
            snake.isHeadOpen = true;

            helpers.playEatSound(soundFx);

            SnakeConfig.FPS++;
        }

        snake.drawSelf(SnakeConfig.canvasContext, SnakeConfig.movementVector, snakeHeadClosed, snakeHeadOpen, false);
        food.drawSelf(SnakeConfig.canvasContext, true, '#000', foodColor);

        snake.isHeadOpen = false;

        foodColor = helpers.updateColor(foodRGBColors);

        var continueLoop = helpers.determineBoundaryCollision(snake);
        if (!continueLoop) {
            endGame(SnakeConfig.canvasContext);
            return;
        }

        setTimeout(function() {
            requestAnimationFrame(gameLoop);
        }, 1000 / SnakeConfig.FPS);
    }


    requestAnimationFrame(gameLoop);
}(GameObjects, snakeConfig, Snake, helpers));