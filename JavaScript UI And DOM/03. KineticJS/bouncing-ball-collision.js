window.onload = function() {
    var MAX_BALL_SIZE = 30;
    var MIN_BALL_SIZE = 15;
    var BALL_COUNT = 5;
    var MASS_RATIO = 2;
    var WIDTH_STEAL = 0.5;
    var colorIncrementSize = 5;

    String.format = function() {
        var result = arguments[0];

        for (var i = 0; i < arguments.length - 1; i++) {
            var matchExpression = new RegExp('\\{' + i + '\\}', 'gm');
            result = result.replace(matchExpression, arguments[i + 1]);
        }

        return result;
    };

    function getRandomValue(min, max) {
        var randomValue = Math.random() * (max - min) + min;
        return randomValue;
    }

    function getRandomColor() {
        var colorR = parseInt(getRandomValue(0, 255));
        var colorG = parseInt(getRandomValue(0, 255));
        var colorB = parseInt(getRandomValue(0, 255));

        return String.format('rgb({0}, {1}, {2})', colorR, colorG, colorB);
    }

    function Direction(x, y) {
        this.x = x;
        this.y = y;
    }

    function Ball(positionX, positionY, radius, speed) {
        this.positionX = positionX;
        this.positionY = positionY;
        this.radius = radius;
        this.speed = speed;
        this.mass = this.radius * MASS_RATIO;

        this.color = getRandomColor();

        this.draw = function(ctx) {
            ctx.beginPath();
            ctx.fillStyle = this.color;
            ctx.strokeStyle = '#000';
            ctx.arc(this.positionX, this.positionY, this.radius, 0, 2 * Math.PI);

            ctx.fill();
            ctx.stroke();
        };

        this.update = function(canvas) {
            this.positionX += this.speed.x;
            this.positionY += this.speed.y;

            if (this.positionX <= this.radius || this.positionX >= canvas.width - this.radius) {
                this.speed.x *= -1;
                this.positionX += this.speed.x;
            }

            if (this.positionY <= this.radius || this.positionY >= canvas.height - this.radius) {
                this.speed.y *= -1;
                this.positionY += this.speed.y;
            }

            this.mass = this.radius * MASS_RATIO;
        }
    }

    function checkBoundaryCollisionXAxis(ball) {
        if (ball.positionX <= ball.radius || ball.positionX >= canvas.width - ball.radius) {
            return true;
        }
    }

    function checkBoundaryCollisionYAxis(ball) {
        if (ball.positionY <= ball.radius || ball.positionY >= canvas.width - ball.radius) {
            return true;
        }
    }

    function detectCollision(firstBall, secondBall) {
        var dX = firstBall.positionX - secondBall.positionX;
        var dY = firstBall.positionY - secondBall.positionY;

        var distance = Math.sqrt((dX * dX) + (dY * dY));

        if (distance <= firstBall.radius + secondBall.radius) {
            return true;
        }

        return false;
    }

    function handleCollision(firstBall, secondBall) {
        var firstBallSpeedX = (firstBall.speed.x * (firstBall.mass - secondBall.mass) + (2 * secondBall.mass * secondBall.speed.x)) /
            (firstBall.mass + secondBall.mass);
        var firstBallSpeedY = (firstBall.speed.y * (firstBall.mass - secondBall.mass) + (2 * secondBall.mass * secondBall.speed.y)) /
            (firstBall.mass + secondBall.mass);
        var secondBallSpeedX = (secondBall.speed.x * (secondBall.mass - firstBall.mass) + (2 * firstBall.mass * firstBall.speed.x)) /
            (secondBall.mass + firstBall.mass);
        var secondBallSPeedY = (secondBall.speed.y * (secondBall.mass - firstBall.mass) + (2 * firstBall.mass * firstBall.speed.y)) /
            (secondBall.mass + firstBall.mass);

        firstBall.speed.x = firstBallSpeedX;
        firstBall.speed.y = firstBallSpeedY;
        firstBall.color = getRandomColor();

        secondBall.speed.x = secondBallSpeedX;
        secondBall.speed.y = secondBallSPeedY;
        secondBall.color = getRandomColor();

        // if (firstBall.radius < secondBall.radius) {
        //     firstBall.radius += WIDTH_STEAL;
        //     secondBall.radius -= WIDTH_STEAL;
        // }

        // if (secondBall.radius < firstBall.radius) {
        //     secondBall.radius += WIDTH_STEAL;
        //     firstBall.radius -= WIDTH_STEAL;
        // }

        while (detectCollision(firstBall, secondBall)) {
            firstBall.positionX += firstBallSpeedX;
            firstBall.positionY += firstBallSpeedY;

            if (firstBall.positionX <= firstBall.radius) {
                firstBall.positionX = firstBall.radius + 1;
            } else if (firstBall.positionX >= canvas.width - firstBall.radius) {
                firstBall.positionX = canvas.width - (firstBall.radius + 1);
            }

            if (firstBall.positionY <= firstBall.radius) {
                firstBall.positionY = firstBall.radius + 1;
            } else if (firstBall.positionY >= canvas.height - firstBall.radius) {
                firstBall.positionY = canvas.height - (firstBall.radius + 1);
            }

            secondBall.positionX += secondBallSpeedX;
            secondBall.positionY += secondBallSPeedY;
            if (secondBall.positionX <= secondBall.radius) {
                secondBall.positionX = secondBall.radius + 1;
            } else if (secondBall.positionX >= canvas.width - secondBall.radius) {
                secondBall.positionX = canvas.width - (secondBall.radius + 1);
            }

            if (secondBall.positionY <= secondBall.radius) {
                secondBall.positionY = secondBall.radius + 1;
            } else if (secondBall.positionY >= canvas.height - secondBall.radius) {
                secondBall.positionY = canvas.height - (secondBall.radius + 1);
            }
        }
    }

    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext('2d');

    var balls = [];

    for (var i = 0; i < BALL_COUNT; i++) {
        var ballSize = getRandomValue(MIN_BALL_SIZE, MAX_BALL_SIZE);
        var randomXPosition = getRandomValue(ballSize, canvas.width);
        if (randomXPosition >= canvas.width - ballSize) {
            randomXPosition -= ballSize;
        }

        var randomYPosition = getRandomValue(ballSize, canvas.height);
        if (randomYPosition >= canvas.height - ballSize) {
            randomYPosition -= ballSize;
        }

        var speedX = getRandomValue(0, 10);
        var speedY = getRandomValue(0, 10);
        var speed = new Direction(speedX, speedY);

        var newBall = new Ball(randomXPosition, randomYPosition, ballSize, speed);
        balls.push(newBall);
    }

    function animationFrame() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        for (var i = 0; i < balls.length; i++) {
            var currentBall = balls[i];

            currentBall.update(canvas);
            currentBall.draw(ctx);
        }

        for (var i = 0; i < balls.length - 1; i++) {
            for (var j = i + 1; j < balls.length; j++) {
                var firstBall = balls[i];
                var secondBall = balls[j];

                if (detectCollision(firstBall, secondBall)) {
                    handleCollision(firstBall, secondBall);
                }
            }
        }


        requestAnimationFrame(animationFrame);
    }

    animationFrame();
};