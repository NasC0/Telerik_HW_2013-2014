var GameObjects = (function() {
    function GameObject(positionX, positionY, radius, startDegrees, endDegrees) {
        this.positionX = positionX;
        this.positionY = positionY;
        this.radius = radius;
        this.startDegrees = startDegrees;
        this.endDegrees = endDegrees;
    }

    GameObject.prototype.drawSelf = function(canvasContext, fillObject, strokeColor, fillColor) {
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
    };

    function Vector(x, y) {
        this.directionX = x;
        this.directionY = y;
    }

    return {
        GameObject: GameObject,
        Vector: Vector
    };
}());