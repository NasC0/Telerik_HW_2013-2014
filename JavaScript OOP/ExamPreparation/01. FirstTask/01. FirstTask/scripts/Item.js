var Item = (function () {
    function Item(content) {
        this.content = content;
    }
    Object.defineProperty(Item.prototype, "content", {
        set: function (content) {
            if (content.length < 0) {
                throw new Error("Item content must be at 1 symbol long.");
            }

            this._content = content;
        },
        enumerable: true,
        configurable: true
    });

    Item.prototype.getData = function () {
        return this._content;
    };
    return Item;
})();
//# sourceMappingURL=Item.js.map
