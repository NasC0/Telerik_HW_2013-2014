define(["./section"], function(Section) {
    'use strict';
    var Container;
    Container = (function() {
        function Container() {
            this._sections = [];
        }

        Container.prototype.add = function(section) {
            if (!(section instanceof Section)) {
                throw new Error('Section to add must be of type Section.');
            }

            if (!section) {
                throw new Error('Section to add must not be undefined.');
            }

            this._sections.push(section);
        };

        Container.prototype.getData = function() {
            var section,
                result = [];
            for (section in this._sections) {
                var currentSectionData = this._sections[section].getData();
                result.push({
                    title: currentSectionData.title,
                    items: currentSectionData.items
                });
            }

            return result;
        };

        return Container;
    }());
    return Container;
});