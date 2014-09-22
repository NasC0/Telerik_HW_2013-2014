$.fn.tabs = function() {
    var $container = this;
    $container.addClass('tabs-container');
    $container.find('.tab-item-content').hide();

    function initializeElement($selectedElement) {
        $selectedElement.addClass('current');
        $selectedElement.find('.tab-item-content').show();
    }

    var $currentSelectedElement = $($container.children()[0]);
    initializeElement($currentSelectedElement);

    $container.on('click', '.tab-item-title', function() {
        var $clickedItem = $(this).parent();

        $currentSelectedElement.removeClass('current');
        $currentSelectedElement.find('.tab-item-content').hide();

        $currentSelectedElement = $clickedItem;
        initializeElement($currentSelectedElement);
    });
};