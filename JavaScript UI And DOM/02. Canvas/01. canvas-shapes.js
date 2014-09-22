////////////////////////////////////////////
// Task 1. Draw graphics using the canvas //
////////////////////////////////////////////
window.onload = function() {
    function drawPerson() {
        var personCanvas = document.getElementById('person-canvas');
        var canvasContext = personCanvas.getContext('2d');

        canvasContext.beginPath();
        canvasContext.strokeStyle = '#21525D';
        canvasContext.fillStyle = '#90CAD7';
        canvasContext.lineWidth = 4;

        // Draw head outline
        canvasContext.save();
        canvasContext.scale(1, 0.9);
        canvasContext.arc(150, 220, 75, 0, 2 * Math.PI);
        canvasContext.stroke();
        canvasContext.fill();

        canvasContext.restore();
        canvasContext.save();

        // Draw mouth
        canvasContext.beginPath();
        canvasContext.rotate(10 * Math.PI / 180);
        canvasContext.scale(1, 0.4);
        canvasContext.arc(175, 520, 30, 0, 2 * Math.PI);
        canvasContext.stroke();

        canvasContext.restore();
        canvasContext.save();

        // Draw nose
        canvasContext.beginPath();
        canvasContext.lineWidth = 3;
        canvasContext.moveTo(140, 170);
        canvasContext.lineTo(125, 205);
        canvasContext.lineTo(145, 205);
        canvasContext.stroke();

        //Draw eyes
        canvasContext.beginPath();
        canvasContext.scale(1, 0.7);
        canvasContext.arc(105, 245, 13, 0, 2 * Math.PI);
        canvasContext.stroke();

        canvasContext.beginPath();
        canvasContext.arc(165, 245, 13, 0, 2 * Math.PI);
        canvasContext.stroke();

        canvasContext.restore();
        canvasContext.save();

        // Draw pupils
        canvasContext.fillStyle = '#21525D';

        canvasContext.scale(0.7, 1);
        canvasContext.beginPath();
        canvasContext.arc(144, 172, 7, 0, 2 * Math.PI);
        canvasContext.fill();

        canvasContext.beginPath();
        canvasContext.arc(230, 172, 7, 0, 2 * Math.PI);
        canvasContext.fill();

        canvasContext.restore();
        canvasContext.save();

        // Draw hat
        canvasContext.strokeStyle = '#262626';
        canvasContext.fillStyle = '#396693';

        //bottom
        canvasContext.beginPath();
        canvasContext.lineWidth = 3;
        canvasContext.moveTo(60, 130);
        canvasContext.bezierCurveTo(70, 160, 210, 160, 220, 130);
        canvasContext.moveTo(60, 130);
        canvasContext.bezierCurveTo(70, 100, 210, 100, 220, 130);
        canvasContext.fill();
        canvasContext.stroke();

        // top
        canvasContext.moveTo(125, 50);
        canvasContext.bezierCurveTo(130, 35, 175, 35, 180, 50);
        canvasContext.moveTo(125, 50);
        canvasContext.bezierCurveTo(130, 65, 175, 65, 180, 50);
        canvasContext.stroke();

        canvasContext.moveTo(125, 120);
        canvasContext.bezierCurveTo(130, 135, 175, 135, 180, 120);
        canvasContext.fill();
        canvasContext.stroke();

        canvasContext.beginPath();
        canvasContext.moveTo(125, 120);
        canvasContext.lineTo(125, 50);
        canvasContext.moveTo(180, 120);
        canvasContext.lineTo(180, 50);
        canvasContext.stroke();
        canvasContext.fill();
    }

    function drawBicycle() {
        var bicycleCanvas = document.getElementById('bicycle-canvas');
        var canvasContext = bicycleCanvas.getContext('2d');

        canvasContext.strokeStyle = '#337D8F';
        canvasContext.fillStyle = '#90CAD7';
        canvasContext.lineWidth = 3;
        canvasContext.translate(-50, 220);

        //Draw wheels
        canvasContext.arc(150, 300, 75, 0, 2 * Math.PI);
        canvasContext.fill();
        canvasContext.stroke();

        canvasContext.beginPath();
        canvasContext.arc(500, 300, 75, 0, 2 * Math.PI);
        canvasContext.fill();
        canvasContext.stroke();

        // Draw frame
        canvasContext.beginPath();
        canvasContext.moveTo(150, 300);
        canvasContext.lineTo(300, 295);
        canvasContext.lineTo(480, 200);
        canvasContext.lineTo(270, 200);
        canvasContext.closePath();
        canvasContext.lineCap = 'round';
        canvasContext.stroke();

        // Draw steering wheel and frame
        canvasContext.beginPath();
        canvasContext.moveTo(500, 300);
        canvasContext.lineTo(475, 150);
        canvasContext.lineTo(510, 120);
        canvasContext.moveTo(475, 150);
        canvasContext.lineTo(425, 160);
        canvasContext.stroke();

        // Draw pedals and seat
        canvasContext.beginPath();
        canvasContext.arc(300, 295, 25, 0, 2 * Math.PI);
        canvasContext.moveTo(300, 295);
        canvasContext.lineTo(250, 160);
        canvasContext.moveTo(220, 160);
        canvasContext.lineTo(280, 160);
        canvasContext.moveTo(280, 280);
        canvasContext.lineTo(260, 260);
        canvasContext.moveTo(320, 315);
        canvasContext.lineTo(335, 330);
        canvasContext.stroke();
    }

    function drawHouse() {
        var canvas = document.getElementById('house-canvas');
        var canvasContext = canvas.getContext('2d');

        canvasContext.translate(420, 0);

        canvasContext.strokeStyle = '#000000';
        canvasContext.fillStyle = '#975B5B';
        canvasContext.lineWidth = 3;

        //Draw house body
        canvasContext.fillRect(150, 390, 600, 400);
        canvasContext.fill();
        canvasContext.strokeRect(150, 390, 600, 400);

        // Draw house roof
        canvasContext.beginPath();
        canvasContext.moveTo(150, 390);
        canvasContext.lineTo(750, 390);
        canvasContext.lineTo(450, 100);
        canvasContext.closePath();
        canvasContext.fill();
        canvasContext.stroke();

        // Draw door
        canvasContext.beginPath();
        canvasContext.moveTo(200, 790);
        canvasContext.lineTo(200, 600);
        canvasContext.bezierCurveTo(220, 550, 330, 550, 350, 600);
        canvasContext.lineTo(350, 790);
        canvasContext.moveTo(275, 790);
        canvasContext.lineTo(275, 562);
        canvasContext.stroke();

        canvasContext.beginPath();
        canvasContext.arc(255, 720, 7, 0, 2 * Math.PI);
        canvasContext.stroke();

        canvasContext.beginPath();
        canvasContext.arc(295, 720, 7, 0, 2 * Math.PI);
        canvasContext.stroke();

        // Draw windows
        canvasContext.fillStyle = '#000';
        canvasContext.fillRect(200, 420, 100, 50);
        canvasContext.fillRect(305, 420, 100, 50);
        canvasContext.fillRect(200, 475, 100, 50);
        canvasContext.fillRect(305, 475, 100, 50);

        canvasContext.fillRect(490, 420, 100, 50);
        canvasContext.fillRect(595, 420, 100, 50);
        canvasContext.fillRect(490, 475, 100, 50);
        canvasContext.fillRect(595, 475, 100, 50);

        canvasContext.fillRect(490, 575, 100, 50);
        canvasContext.fillRect(595, 575, 100, 50);
        canvasContext.fillRect(490, 630, 100, 50);
        canvasContext.fillRect(595, 630, 100, 50);

        // Draw chimney
        canvasContext.fillStyle = '#975B5B';
        canvasContext.beginPath();
        canvasContext.moveTo(630, 300);
        canvasContext.lineTo(630, 150);
        canvasContext.moveTo(580, 300);
        canvasContext.lineTo(580, 150);
        canvasContext.stroke();

        canvasContext.beginPath();
        canvasContext.moveTo(580, 150);
        canvasContext.bezierCurveTo(585, 143, 625, 143, 630, 150);
        canvasContext.moveTo(580, 150);
        canvasContext.bezierCurveTo(585, 157, 625, 157, 630, 150);
        canvasContext.fill();
        canvasContext.stroke();
    }

    drawPerson();
    drawBicycle();
    drawHouse();
};