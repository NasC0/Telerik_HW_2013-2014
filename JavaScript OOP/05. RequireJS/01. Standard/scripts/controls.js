define(['jquery', 'handlebars'], function($) {
    var ComboBox = (function(people) {
        this._people = people;
    });

    ComboBox.prototype.render = function(handlebarsTemplate) {
        var compiledTemplate = Handlebars.compile(handlebarsTemplate);
        var html = compiledTemplate({
            person: this._people
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

        return $parent;
    };

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

    return {
        ComboBox: ComboBox
    };
});