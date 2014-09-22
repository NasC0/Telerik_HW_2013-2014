/////////////////////////////////////////////////////////////
// Task 1.                                                 //
// Create a module for drawing shapes using Canvas.        //
// Implement the following shapes:                         //
// Rect, by given position (X, Y) and size (Width, Height) //
// Circle, by given center position (X, Y) and radius (R)  //
// Line, by given from (X1, Y1) and to (X2, Y2) positions  //
/////////////////////////////////////////////////////////////

var ExtendedCanvas = (function() {
    function ExtendedCanvas(selector) {
        if (!(this instanceof arguments.callee)) {
            return new arguments.callee(selector);
        }

        this._canvas = document.querySelector(selector);
        this.context = this._canvas.getContext('2d');
    }

    ExtendedCanvas.prototype.rect = function(posX, posY, width, height) {
        this.context.beginPath();
        this.context.rect(posX, posY, width, height);
        this.context.stroke();
    };

    ExtendedCanvas.prototype.circle = function(posX, posY, radius) {
        this.context.beginPath();
        this.context.arc(posX, posY, radius, 0, 2 * Math.PI);
        this.context.stroke();
    };

    ExtendedCanvas.prototype.line = function(startPosX, startPosY, endPosX, endPosY) {
        this.context.beginPath();
        this.context.moveTo(startPosX, startPosY);
        this.context.lineTo(endPosX, endPosY);
        this.context.stroke();
    };

    return ExtendedCanvas;
}());