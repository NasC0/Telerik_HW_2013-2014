var FONT_SIZE = 13;
var FATHER_BORDER_COLOR = '#77B300';
var MOTHER_BORDER_COLOR = '#B200FF';
var SINGLE_BORDER_COLOR = '#5B5BFF';
var RECTANGLE_WIDTH = 140;
var RECTANGLE_MIDDLE = RECTANGLE_WIDTH / 2;
var GAP_BETWEEN_RECTANGLES = 80;
var LINE_HEIGHT = 150;
var START_DRAW_POSITION_X = 20;
var START_DRAW_POSITION_Y = -100;
var TEXT_COLOR = '#000';
var FONT_FAMILY = 'Calibri';

// TODO: make rectangle and text calculations happen here
// and extrapolate line drawing between heirs in the draw() method
function prepareDrawing(treeHiearchy, drawLayer, stage) {
    var maxLevelWidth = 0;
    var height = 0;
    var bfsQueue = [];
    bfsQueue.push(treeHiearchy);

    var depthsCount = {};

    var drawPositionX = START_DRAW_POSITION_X;
    var drawPositionY = START_DRAW_POSITION_Y;

    while (bfsQueue.length > 0) {
        var currentNode = bfsQueue.shift();

        if (depthsCount[currentNode.depth] === undefined) {
            depthsCount[currentNode.depth] = 0;
            height++;
            drawPositionX = START_DRAW_POSITION_X;
            drawPositionY += LINE_HEIGHT;
        }

        depthsCount[currentNode.depth]++;

        if (depthsCount[currentNode.depth] > maxLevelWidth) {
            maxLevelWidth = depthsCount[currentNode.depth];
        }

        if (currentNode.hasOwnProperty('children')) {
            for (var i = 0; i < currentNode.children.length; i++) {
                bfsQueue.push(currentNode.children[i]);
            }

            var fatherText = prepareText(drawPositionX, drawPositionY, RECTANGLE_WIDTH, 10, currentNode.father);
            var fatherRectangle = prepareRectangle(drawPositionX, drawPositionY, RECTANGLE_WIDTH, fatherText.height(), FATHER_BORDER_COLOR, 10);
            currentNode.fatherShape = new Shape(fatherText, fatherRectangle);
            drawPositionX += GAP_BETWEEN_RECTANGLES + RECTANGLE_WIDTH;

            var motherText = prepareText(drawPositionX, drawPositionY, RECTANGLE_WIDTH, 10, currentNode.mother);
            var motherRectangle = prepareRectangle(drawPositionX, drawPositionY, RECTANGLE_WIDTH, motherText.height(), MOTHER_BORDER_COLOR, 10);
            currentNode.motherShape = new Shape(motherText, motherText);
            drawPositionX += GAP_BETWEEN_RECTANGLES + RECTANGLE_WIDTH;

            drawLayer.add(fatherRectangle);
            drawLayer.add(fatherText);

            drawLayer.add(motherRectangle);
            drawLayer.add(motherText);
        } else {
            var text = prepareText(drawPositionX, drawPositionY, RECTANGLE_WIDTH, 10, currentNode.name);
            var rectangle = prepareRectangle(drawPositionX, drawPositionY, RECTANGLE_WIDTH, text.height(), SINGLE_BORDER_COLOR, 10, true);
            currentNode.shape = new Shape(text, rectangle);
            drawPositionX += GAP_BETWEEN_RECTANGLES + RECTANGLE_WIDTH;

            drawLayer.add(rectangle);
            drawLayer.add(text);
        }
    }

    return [maxLevelWidth, height];
}

function prepareText(drawPositionX, drawPositionY, inputWidth, inputPadding, inputText) {
    var text = new Kinetic.Text({
        x: drawPositionX,
        y: drawPositionY,
        text: inputText,
        fill: TEXT_COLOR,
        fontSize: FONT_SIZE,
        fontFamily: FONT_FAMILY,
        width: inputWidth,
        padding: inputPadding,
        align: 'center',
    });

    return text;
}

function prepareRectangle(drawPositionX, drawPositionY, inputWidth, inputHeight, borderColor, cornerRadius, dashed) {
    var rectangle = new Kinetic.Rect({
        x: drawPositionX,
        y: drawPositionY,
        width: inputWidth,
        height: inputHeight,
        stroke: borderColor,
        strokeWidth: 2,
        cornerRadius: cornerRadius
    });

    if (dashed) {
        rectangle.dash([10, 5]);
    }

    return rectangle;
}

function connectNodes(fatherShape, motherShape, childShape, drawLayer, colorToUse) {
    var fatherNodePosition = fatherShape.rectangle.position();
    var motherNodePosition = motherShape.rectangle.position();
    var beginParentsConnection = fatherNodePosition.x + RECTANGLE_WIDTH;
    var parentsConnectionMiddleHeight = fatherNodePosition.y + fatherShape.rectangle.height() / 0.8;

    var connectParentsLine = new Kinetic.Line({
        points: [fatherNodePosition.x + RECTANGLE_WIDTH - 5, fatherNodePosition.y + fatherShape.rectangle.height(),
            beginParentsConnection, parentsConnectionMiddleHeight, motherNodePosition.x, parentsConnectionMiddleHeight,
            motherNodePosition.x + 5, motherNodePosition.y + motherShape.rectangle.height()
        ],
        stroke: colorToUse,
        strokeWidth: 1,
        tension: 0.2
    });

    drawLayer.add(fatherShape.text);
    drawLayer.add(fatherShape.rectangle);
    drawLayer.add(motherShape.text);
    drawLayer.add(motherShape.rectangle);
    drawLayer.add(connectParentsLine);

    var childNodePosition = childShape.rectangle.position();
    var childNodeXStart = beginParentsConnection + GAP_BETWEEN_RECTANGLES / 2;
    var childNodeXEnd = childNodePosition.x + RECTANGLE_WIDTH / 2;
    var childNodeYStart = parentsConnectionMiddleHeight;
    var childNodeYEnd = childNodePosition.y;

    var parentsToChildLine = new Kinetic.Line({
        points: [childNodeXStart, childNodeYStart, childNodeXEnd, childNodeYEnd],
        stroke: colorToUse,
        strokeWidth: 1,
    });

    drawLayer.add(childShape.text);
    drawLayer.add(childShape.rectangle);
    drawLayer.add(parentsToChildLine);
}

function draw(treeHiearchy, drawLayer) {
    var bfsQueue = [treeHiearchy];

    while (bfsQueue.length > 0) {
        var currentNode = bfsQueue.shift();

        for (var i in currentNode.children) {
            bfsQueue.push(currentNode.children[i]);

            var shape;
            if (currentNode.children[i] instanceof FamilyNode) {
                if (currentNode.directChildren[i] === currentNode.children[i].father) {
                    shape = currentNode.children[i].fatherShape;
                } else {
                    shape = currentNode.children[i].motherShape;
                }
            } else if (currentNode.children[i] instanceof SingleNode) {
                shape = currentNode.children[i].shape;
            }

            connectNodes(currentNode.fatherShape, currentNode.motherShape, shape, drawLayer, FATHER_BORDER_COLOR);
        }
    }
}