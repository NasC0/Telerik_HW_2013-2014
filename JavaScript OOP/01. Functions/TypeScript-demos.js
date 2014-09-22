var Animal = (function () {
    function Animal(name, age) {
        this.age = age;
        this.name = name;
        this._isAlive = true;
    }
    Object.defineProperty(Animal.prototype, "name", {
        get: function () {
            return this._name;
        },
        set: function (name) {
            if (!name) {
                throw new Error('Name value cannot be undefined.');
            }

            if (name.length <= 0) {
                throw new Error('Name value must be at least 1 symbol long.');
            }

            this._name = name;
        },
        enumerable: true,
        configurable: true
    });


    Animal.prototype.kill = function () {
        this._isAlive = false;
    };
    return Animal;
})();
