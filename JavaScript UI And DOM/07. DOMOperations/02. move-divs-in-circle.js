//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 2. Write a script that creates 5 div elements and moves them in circular path with interval of 100 milliseconds //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

window.onload = function() {
    var DIV_COUNT = 5;
    var startAngle = 0;
    var center = {
        x: 500,
        y: 300,
        radius: 200
    };

    var container = document.getElementById('container');
    var divTemplate = document.createElement('div');
    divTemplate.style.border = '2px solid black';
    divTemplate.style.width = '10px';
    divTemplate.style.height = '10px';
    divTemplate.style.borderRadius = '25px';
    divTemplate.style.position = 'absolute';


    function moveDiv(center, angle) {
        var position = {
            x: center.x + center.radius * Math.cos(angle),
            y: center.y + center.radius * Math.sin(angle)
        }

        return position;
    }

    setInterval(function() {
        startAngle += 0.05;

        while (container.firstChild) {
            container.removeChild(container.firstChild);
        }

        var documentFragment = document.createDocumentFragment();

        for (var i = 0; i < DIV_COUNT; i++) {
            var currentDiv = divTemplate.cloneNode(true);
            var currentAngle = startAngle + i * 2 * Math.PI / DIV_COUNT;
            var currentDivPosition = moveDiv(center, currentAngle);
            currentDiv.style.top = currentDivPosition.y + 'px';
            currentDiv.style.left = currentDivPosition.x + 'px';

            documentFragment.appendChild(currentDiv);
        }

        container.appendChild(documentFragment);
    }, 100);
}