// Task 1. Create a jQuery plugin for creating dropdown list
// Executes on a Select element, which makes it invisible and
// creates a list of selectable options

$.fn.dropdown = function() {
    var $this = $(this);
    $this.css('display', 'none');
    var $divWrapper = $(document.createElement('div'))
        .addClass('dropdown-list-container');
    var $ulWrapper = $(document.createElement('ul'))
        .addClass('dropdown-list-options');
    var $liTemplate = $(document.createElement('li'))
        .addClass('dropdown-list-option');

    var $selectableOptions = $this.children();

    $ulWrapper.on('click', 'li', function() {
        var $selectedLi = $(this);
        var optionValue = $selectedLi.data('value');
        var $correspondingOption = $this.find('option[value="' + optionValue + '"]');

        $selectableOptions.attr('selected', false);
        $ulWrapper.children().css('background-color', '');

        $correspondingOption.attr('selected', true);
        $selectedLi.css('background-color', 'green');
    });

    for (var i = 0; i < $selectableOptions.length; i++) {
        var $currentOption = $liTemplate.clone(false);
        $currentOption.attr('data-value', $selectableOptions[i].value);
        $currentOption.html($($selectableOptions[i]).html());

        $currentOption.appendTo($ulWrapper);
    }

    $divWrapper.append($ulWrapper);
    $divWrapper.insertAfter($this);

    return $this;
};