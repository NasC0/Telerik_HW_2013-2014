window.onload = function() {
    var inputData = defaultTest;

    console.time('Full execution');
    console.time('getFullHiearchy');
    var wholeTreeHiearchy = getFullHiearchy(inputData);
    console.timeEnd('getFullHiearchy')

    var drawLayer = new Kinetic.Layer({
        draggable: true
    });

    console.time('prepareDrawing');
    var widthAndHeight = prepareDrawing(wholeTreeHiearchy, drawLayer);
    console.timeEnd('prepareDrawing');

    console.time('draw');
    draw(wholeTreeHiearchy, drawLayer, widthAndHeight[1]);
    console.timeEnd('draw');

    console.time('Stage preparation');

    var stage = new Kinetic.Stage({
        container: 'canvas',
        width: widthAndHeight[0] * ((RECTANGLE_WIDTH + GAP_BETWEEN_RECTANGLES) * 2),
        height: widthAndHeight[1] * LINE_HEIGHT
    });

    stage.add(drawLayer);

    console.timeEnd('Stage preparation');
    console.timeEnd('Full execution');

    console.log(wholeTreeHiearchy)
};