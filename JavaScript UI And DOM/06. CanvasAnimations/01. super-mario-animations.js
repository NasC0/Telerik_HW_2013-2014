window.onload = function() {
    var WIDTH = 640;
    var HEIGHT = 400;


    var stage = new Kinetic.Stage({
        container: 'wrapper',
        width: WIDTH,
        height: HEIGHT
    });

    var layer = new Kinetic.Layer();

    var imageObj = new Image();
    imageObj.onload = function() {
        var mario = new Kinetic.Sprite({
            x: 125,
            y: 295,
            image: imageObj,
            animation: 'run',
            animations: {
                run: [
                    // x, y, width, height (4 frames)
                    39, 102, 25, 27,
                    74, 102, 25, 27,
                    109, 102, 25, 27,
                    145, 102, 25, 27
                ]
            },
            frameRate: 7,
            frameIndex: 0
        });

        layer.add(mario);
        stage.add(layer);
        mario.start();
    };

    imageObj.src = 'images/HEYYOUGETOFFAMYCLOUD.png';


    var paper = Raphael(0, 0, WIDTH, HEIGHT);
    paper.image("images/Super-Mario-By-Andrestorres12-Game-Wallpaper.jpg", 0, 0, WIDTH, HEIGHT);
    // var stage = new Kinetic.Stage({
    //     container: 'wrapper',
    //     width: 578,
    //     height: 200
    // });
    // var layer = new Kinetic.Layer();

    // var imageObj = new Image();
    // imageObj.onload = function() {
    //     var mario = new Kinetic.Sprite({
    //         x: 250,
    //         y: 40,
    //         image: imageObj,
    //         animation: 'run',
    //         animations: {
    //             run: [
    //                 // x, y, width, height (4 frames)
    //                 39, 102, 25, 27,
    //                 74, 102, 25, 27,
    //                 109, 102, 25, 27,
    //                 145, 102, 25, 27
    //             ]
    //         },
    //         frameRate: 7,
    //         frameIndex: 0
    //     });

    //     // add the shape to the layer
    //     layer.add(mario);

    //     // add the layer to the stage
    //     stage.add(layer);

    //     // start sprite animation
    //     mario.start();
    // };
}