define(["./item"], function(Item) {
    'use strict';
    var Section;
    Section = (function() {
        function Section(title) {
            this.title = title;
            this._items = [];
        }

        Section.prototype.add = function(item) {
            if (!item) {
                throw new Error('Item to add cannot be undefined');
            }

            if (!(item instanceof Item)) {
                throw new Error('Item to add must be of type Item');
            }

            this._items.push(item);
        };

        Section.prototype.getData = function() {
            return {
                title: this.title,
                items: this._items
            };
        };

        return Section;
    }());
    return Section;
});