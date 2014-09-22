////////////////////////////////////////////////////////////////////////////
// Task 1. Create a slider control using jQuery                           //
// The slider can have many slides                                        //
// Only one slide is visible at a time                                    //
// Each slide contains HTML code                                          //
// i.e. it can contain images, forms, divs, headers, links, etc…          //
// Implement functionality for changing the visible slide after 5 seconds //
// Create buttons for next and previous slide                             //
////////////////////////////////////////////////////////////////////////////

window.onload = function() {
    function makeSlider(container) {
        var $container = $(container);
        var $availableChildren = $container.children();
        var $currentAcitveSlide = $($availableChildren[0]);
        $currentAcitveSlide.show();

        function nextSlide() {
            var $previousActiveSlide = $currentAcitveSlide;
            $currentAcitveSlide = $currentAcitveSlide.next();

            if (!$currentAcitveSlide.hasClass('slider-element')) {
                $currentAcitveSlide = $($availableChildren[0]);
            }

            $previousActiveSlide.fadeOut(500, function() {
                $currentAcitveSlide.fadeIn(500);
            });

            clearInterval(interval);
            interval = setInterval(nextSlide, 5000);
        }

        function previousSlide() {
            var $previousActiveSlide = $currentAcitveSlide;
            $currentAcitveSlide = $currentAcitveSlide.prev();

            if (!$currentAcitveSlide.hasClass('slider-element')) {
                $currentAcitveSlide = $($availableChildren[$availableChildren.length - 1]);
            }

            $previousActiveSlide.fadeOut(500, function() {
                $currentAcitveSlide.fadeIn(500);
            });

            clearInterval(interval);
            interval = setInterval(nextSlide, 5000);
        }

        var $nextButton = $(document.createElement('button'));
        $nextButton.html('Next');
        $nextButton.on('click', nextSlide);
        $nextButton.appendTo($container);

        var $prevButton = $(document.createElement('button'));
        $prevButton.html('Previous');
        $prevButton.on('click', previousSlide);
        $prevButton.appendTo($container);

        var interval = setInterval(nextSlide, 5000);
    }

    makeSlider('#slider-container');

};