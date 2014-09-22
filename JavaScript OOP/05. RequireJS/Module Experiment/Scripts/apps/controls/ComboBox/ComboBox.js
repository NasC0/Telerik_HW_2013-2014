define(['jquery', 'handlebars'], function($) {
    function ComboBox(people) {
        this._people = people;
    }

    ComboBox.prototype.render = function(templateSelector) {
        var template = Handlebars.compile($(templateSelector).html());
        var compiledHtml = template({
            person: this._people
        });

        var $container = $('<div/>').html(compiledHtml);

        var $comboItems = $container.find('.combo-item');
        $comboItems.hide();
        $comboItems.first().addClass('selected').show();

        $container.on('click', '.combo-item', function() {
            var $this = $(this);
            if ($this.is(':visible')) {
                $this.removeClass('selected');
                $comboItems.show();
            } else {
                $this.addClass('selected');
                $comboItems.hide();
                $this.show();
            }
        });

        return $container;
    };

    return ComboBox;
});