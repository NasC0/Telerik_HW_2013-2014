window.onload = function() {

    var FONT_SIZE = 13;
    var FATHER_BORDER_COLOR = '#77B300';
    var MOTHER_BORDER_COLOR = '#B200FF';
    var SINGLE_BORDER_COLOR = '#5B5BFF';
    var RECTANGLE_WIDTH = 140;
    var RECTANGLE_MIDDLE = RECTANGLE_WIDTH / 2;
    var GAP_BETWEEN_RECTANGLES = 20;
    var LINE_HEIGHT = 100;
    var START_DRAW_POSITION_X = 20;
    var START_DRAW_POSITION_Y = 20;
    var TEXT_COLOR = '#000';
    var FONT_FAMILY = 'Calibri';

    function FamilyNode(mother, father, children, depth, directChildren) {
        this.mother = mother;
        this.father = father;
        this.children = children;
        this.depth = depth;
        this.directChildren = directChildren;

        var positionInLevel;
    }

    function SingleNode(name, depth) {
        this.name = name;
        this.depth = depth;

        var positionInLevel;
    }

    function findAncestors(originalFamilyTree) {
        for (var i = 0; i < originalFamilyTree.length; i++) {

            var currentMotherName = originalFamilyTree[i].mother;
            var currentFatherName = originalFamilyTree[i].father;

            var isPresent = false;

            for (var j = 0; j < originalFamilyTree.length; j++) {
                var currentNodeChildren = originalFamilyTree[j].children;

                for (var p = 0; p < currentNodeChildren.length; p++) {
                    if (currentMotherName === currentNodeChildren[p] || currentFatherName === currentNodeChildren[p]) {
                        isPresent = true;
                    }
                }
            }

            if (!isPresent) {
                return originalFamilyTree[i];
            }
        }
    }

    function getFamilyNode(parentName, familyTree) {
        for (var i = 0; i < familyTree.length; i++) {
            if (familyTree[i].mother === parentName || familyTree[i].father === parentName) {
                return familyTree[i];
            }
        }
    }

    function getTreeHiearchy(ancestors, familyTree, depth) {
        var mother = ancestors.mother;
        var father = ancestors.father;

        var unprocessedChildren = ancestors.children;
        var childrenNodes = [];

        for (var i = 0; i < unprocessedChildren.length; i++) {
            var currentChild = unprocessedChildren[i];
            var currentChildFamilyNode = getFamilyNode(currentChild, familyTree);

            if (currentChildFamilyNode === undefined) {
                var singleNode = new SingleNode(currentChild, depth + 1);
                childrenNodes.push(singleNode);

                continue;
            }

            var currentNodeChildren = getTreeHiearchy(currentChildFamilyNode, familyTree, depth + 1);

            childrenNodes.push(currentNodeChildren);
        }

        var familyNode = new FamilyNode(mother, father, childrenNodes, depth, unprocessedChildren);
        return familyNode;
    }

    function getFullHiearchy(familyTree) {
        var primeAncestors = findAncestors(familyTree);
        var hiearchy = getTreeHiearchy(primeAncestors, familyTree, 0);

        return hiearchy;
    }


    // TODO: make rectangle and text calculations happen here
    // and extrapolate line drawing between heirs in the draw() method
    function getTreeDimensionsAndPrepareDrawing(treeHiearchy) {
        var maxLevelWidth = 0;
        var height = 0;
        var bfsQueue = [];
        bfsQueue.push(treeHiearchy);

        var depthsCount = {};
        var currentElementPosition = 0;

        while (bfsQueue.length > 0) {
            var currentNode = bfsQueue.shift();

            if (depthsCount[currentNode.depth] === undefined) {
                currentElementPosition = 0;
                depthsCount[currentNode.depth] = 0;
                height++;
            }

            currentNode.positionInLevel = currentElementPosition;

            depthsCount[currentNode.depth]++;

            if (depthsCount[currentNode.depth] > maxLevelWidth) {
                maxLevelWidth = depthsCount[currentNode.depth];
            }

            if (currentNode.hasOwnProperty('children')) {
                for (var i = 0; i < currentNode.children.length; i++) {
                    bfsQueue.push(currentNode.children[i]);
                }

                currentElementPosition += 2;
            } else {
                currentElementPosition += 1;
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
            align: 'center'
        });

        return text;
    }

    function prepareRectangle(drawPositionX, drawPositionY, inputWidth, inputHeight, borderColor, cornerRadius, dashed) {
        var rectangle;
        if (dashed) {
            rectangle = new Kinetic.Rect({
                x: drawPositionX,
                y: drawPositionY,
                width: inputWidth,
                height: inputHeight,
                stroke: borderColor,
                strokeWidth: 2,
                cornerRadius: cornerRadius,
                dash: [10, 5]
            });
        } else {
            rectangle = new Kinetic.Rect({
                x: drawPositionX,
                y: drawPositionY,
                width: inputWidth,
                height: inputHeight,
                stroke: borderColor,
                strokeWidth: 2,
                cornerRadius: cornerRadius
            });
        }

        return rectangle;
    }

    function draw(treeHiearchy, drawLayer, stage) {
        var bfsQueue = [];
        bfsQueue.push(treeHiearchy);

        var currentDepth = 0;
        var drawPositionX = START_DRAW_POSITION_X;
        var drawPositionY = START_DRAW_POSITION_Y;

        while (bfsQueue.length > 0) {
            var currentNode = bfsQueue.shift();

            if (currentNode.depth > currentDepth) {
                currentDepth++;
                drawPositionX = START_DRAW_POSITION_X;
                drawPositionY += LINE_HEIGHT;
            }

            if (currentNode instanceof FamilyNode) {
                var fatherText = prepareText(drawPositionX, drawPositionY, RECTANGLE_WIDTH, 10, currentNode.father);
                var fatherRectangle = prepareRectangle(drawPositionX, drawPositionY, RECTANGLE_WIDTH, fatherText.height(), FATHER_BORDER_COLOR, 10);
                drawPositionX += GAP_BETWEEN_RECTANGLES + RECTANGLE_WIDTH;

                var motherText = prepareText(drawPositionX, drawPositionY, RECTANGLE_WIDTH, 10, currentNode.mother);
                var motherRectangle = prepareRectangle(drawPositionX, drawPositionY, RECTANGLE_WIDTH, motherText.height(), MOTHER_BORDER_COLOR, 10);
                drawPositionX += GAP_BETWEEN_RECTANGLES + RECTANGLE_WIDTH;

                drawLayer.add(fatherRectangle);
                drawLayer.add(fatherText);

                drawLayer.add(motherRectangle);
                drawLayer.add(motherText);

                stage.add(drawLayer);

                if (currentNode.hasOwnProperty('children')) {
                    for (var i = 0; i < currentNode.children.length; i++) {
                        bfsQueue.push(currentNode.children[i]);
                    }
                }

            } else {
                var text = prepareText(drawPositionX, drawPositionY, RECTANGLE_WIDTH, 10, currentNode.name);
                var rectangle = prepareRectangle(drawPositionX, drawPositionY, RECTANGLE_WIDTH, text.height(), SINGLE_BORDER_COLOR, 10, true);

                drawPositionX += GAP_BETWEEN_RECTANGLES + RECTANGLE_WIDTH;

                drawLayer.add(rectangle);
                drawLayer.add(text);
                stage.add(drawLayer);
            }
        }

        stage.add(drawLayer);
    }

    var inputData = defaultTest;

    var wholeTreeHiearchy = getFullHiearchy(inputData);
    var counts = getTreeDimensionsAndPrepareDrawing(wholeTreeHiearchy);

    var stage = new Kinetic.Stage({
        container: 'canvas',
        width: counts[0] * 300,
        height: counts[1] * 100
    });

    var drawLayer = new Kinetic.Layer();

    draw(wholeTreeHiearchy, drawLayer, stage);

    stage.add(drawLayer);

    console.log(wholeTreeHiearchy)
};