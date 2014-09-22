////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 1. Write a script that creates a number of div elements. Each div element must have the following //
// Random width and height between 20px and 100px                                                         //
// Random background color                                                                                //
// Random font color                                                                                      //
// Random position on the screen (position:absolute)                                                      //
// A strong element with text "div" inside the div                                                        //
// Random border radius                                                                                   //
// Random border color                                                                                    //
// Random border width between 1px and 20px                                                               //
////////////////////////////////////////////////////////////////////////////////////////////////////////////


window.onload = function() {
    var MAX_WIDTH_HEIGHT = 100;
    var MIN_WIDTH_HEIGHT = 20;
    var MIN_BORDER_WIDTH = 1;
    var MAX_BORDER_WIDTH = 20;


    String.format = function() {
        var result = arguments[0];

        for (var i = 0; i < arguments.length - 1; i++) {
            var matchExpression = new RegExp('\\{' + i + '\\}', 'gm');
            result = result.replace(matchExpression, arguments[i + 1]);
        }

        return result;
    };

    function getRandomColor() {
        var colorR = getRandomValue(0, 255);
        var colorG = getRandomValue(0, 255);
        var colorB = getRandomValue(0, 255);

        return String.format('rgb({0}, {1}, {2})', colorR, colorG, colorB);
    }

    function getRandomValue(min, max) {
        var randomValue = Math.floor(Math.random() * (max - min) + min);

        return randomValue;
    }

    function generateDivs(divCount) {
        var divFragment = document.createDocumentFragment();
        var innerElementTemplate = document.createElement('strong');
        innerElementTemplate.innerHTML = 'div';

        for (var i = 0; i < divCount; i++) {
            var divWidth = getRandomValue(MIN_WIDTH_HEIGHT, MAX_WIDTH_HEIGHT);
            var divHeight = getRandomValue(MIN_WIDTH_HEIGHT, MAX_WIDTH_HEIGHT);
            var backgroundColor = getRandomColor();
            var fontColor = getRandomColor();
            var positionX = getRandomValue(0, window.innerWidth);
            var positionY = getRandomValue(0, window.innerHeight);
            var borderRadius = getRandomValue(0, 100);
            var borderColor = getRandomColor();
            var borderWidth = getRandomValue(MIN_BORDER_WIDTH, MAX_BORDER_WIDTH);

            var currentDiv = document.createElement('div');
            currentDiv.appendChild(innerElementTemplate.cloneNode(true));
            currentDiv.style.width = divWidth + 'px';
            currentDiv.style.height = divHeight + 'px';
            currentDiv.style.backgroundColor = backgroundColor;
            currentDiv.style.color = fontColor;
            currentDiv.style.position = 'absolute';
            currentDiv.style.top = positionY + 'px';
            currentDiv.style.left = positionX + 'px';
            currentDiv.style.borderRadius = borderRadius + 'px';
            currentDiv.style.border = borderWidth + 'px solid ' + borderColor;

            divFragment.appendChild(currentDiv);
        }

        document.body.appendChild(divFragment);
    }

    generateDivs(5);
}