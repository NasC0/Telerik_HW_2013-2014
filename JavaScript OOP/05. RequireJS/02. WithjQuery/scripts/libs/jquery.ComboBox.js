define(['jquery', 'handlebars'], function($) {
    $.fn.ComboBox = function(templateContainer, people) {
        var template = Handlebars.compile($(templateContainer).html());
        var html = template({
            person: people
        });

        var $parent = $('<div/>');
        $parent.html(html);

        var $personItems = $parent.find('.combo-item');
        $personItems.hide();
        $personItems.first().show().addClass('selected');

        $parent.on('click', '.combo-item', function() {
            var $this = $(this);
            if ($this.hasClass('selected')) {
                $this.removeClass('selected');

                animateClickedElement($this);
                $personItems.show("fast");
                return;
            }

            $personItems.each(function() {
                if (!($this.is($(this)))) {
                    $(this).hide("fast");
                } else {
                    animateClickedElement($(this));
                }
            });
            $this.addClass('selected');
        });

        function animateClickedElement($element) {
            if ($element.is(':animated')) {
                return;
            }

            var elementWidth = parseInt($element.width());
            var incrementedElementWidth = elementWidth + 50;

            $element.animate({
                width: incrementedElementWidth
            }, 75);

            $element.animate({
                width: elementWidth
            }, 75);
        }

        $(this).append($parent);
    };
});