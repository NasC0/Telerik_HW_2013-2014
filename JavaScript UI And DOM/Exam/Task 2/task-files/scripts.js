$.fn.gallery = function() {
    var galleryRows = arguments[0];

    if (galleryRows === undefined) {
        galleryRows = 4;
    }

    var $container = $(this);
    $container.addClass('gallery');
    $container.find('.selected').hide();

    if (galleryRows !== 4) {
        $container.find('.image-container:nth-of-type(' + galleryRows + 'n+1)').each(function() {
            var $selected = $(this);
            $selected.addClass('clearfix');
        });
    }

    $container.on('click', '.image-container img', enlargeImage);
    $container.on('click', '#previous-image', enlargeImage);
    $container.on('click', '#next-image', enlargeImage);
    $container.on('click', '#current-image', function() {
        $container.find('.gallery-list').removeClass('blurred');
        $container.find('.selected').hide();
    });

    function enlargeImage() {
        var $clickedImage = $(this);
        var $selectedContainer = $container.find('.selected');

        if ($selectedContainer.is(':hidden') || $clickedImage.parent().parent().hasClass('selected')) {
            $selectedContainer.find('div img').each(function() {
                $(this).remove();
            });

            var $currentImage = $('<img/>')
                .attr('src', $clickedImage.attr('src'))
                .attr('id', 'current-image')
                .appendTo('div.current-image');

            var clickedImageValue = $container.find('.gallery-list img[src="' + $clickedImage.attr('src') + '"]')
                .data('info');

            var previousImageValue = clickedImageValue - 1;
            if (previousImageValue < 1) {
                previousImageValue = $container.find('.image-container img').length;
            }

            var nextImageValue = clickedImageValue + 1;
            if (nextImageValue > $container.find('.image-container img').length) {
                nextImageValue = 1;
            }

            var $previousImageParent = $container.find('.gallery-list img[data-info="' + previousImageValue + '"]');
            var $nextImage = $container.find('.gallery-list img[data-info="' + nextImageValue + '"]');

            var $previousImageSelected = $('<img/>')
                .attr('src', $previousImageParent.attr('src'))
                .attr('id', 'previous-image')
                .appendTo('div.previous-image');

            var $nextImageSelected = $('<img/>')
                .attr('src', $nextImage.attr('src'))
                .attr('id', 'next-image')
                .appendTo('div.next-image');

            $selectedContainer.show();
            $container.find('.gallery-list').addClass('blurred');
        }
    }
};