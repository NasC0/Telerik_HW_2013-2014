define(['underscore'], function(_) {
    var Animal,
        validNumberOfLegs = [2, 4, 6, 8, 100];

    Animal = (function() {
        function Animal(species, numberOfLegs) {
            this.species(species);
            this.legs(numberOfLegs);
        }

        Animal.prototype.species = function(species) {
            if (species === undefined) {
                return this._species;
            } else {
                if (typeof(species) === 'string') {
                    this._species = species;
                }
            }
        };

        Animal.prototype.legs = function(numberOfLegs) {
            if (numberOfLegs === undefined) {
                return this._legs;
            } else {
                if (typeof(numberOfLegs) === 'number' && _.contains(validNumberOfLegs, numberOfLegs)) {
                    this._legs = numberOfLegs;
                } else {
                    throw new Error('Number of legs must be either 2, 4, 6, 8 or 100');
                }
            }
        };

        return Animal;
    }());

    return Animal;
});