//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Task 3. Write a function that makes a deep copy of an object. The function should work for both primitive and reference types //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



function solve() {

    function Person(firstName, lastName, visibleAge, hairColor, hairType, eyeColor, eyeType) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.appearance = {
            age: visibleAge,
            hair: {
                type: hairType,
                color: hairColor
            },
            eyes: {
                type: eyeType,
                color: eyeColor
            }
        };
    }

    // Deep copy using recursion
    function DeepCopy(toCopy) {
        var result;

        if (typeof toCopy !== 'object') {
            result = toCopy;
            return result;
        } else {
            result = {};
            for (var prop in toCopy) {
                if (typeof toCopy[prop] !== 'object') {
                    result[prop] = toCopy[prop];
                } else {
                    result[prop] = DeepCopy(toCopy[prop]);
                }
            }

            return result;
        }
    }

    // Tests
    var firstPerson = new Person('Pesho', 'Toshev', 23, 'black', 'straight', 'blue', 'asian');
    var secondPerson = DeepCopy(firstPerson);
    var thirdPerson = firstPerson;

    console.log(secondPerson);
    secondPerson.firstName = 'Gosho';
    firstPerson.firstName = 'Tisho';
    secondPerson.appearance = {
        age: 55,
        hair: {
            type: 'curly',
            color: 'blue'
        },
        eyes: {
            type: 'scandinavian',
            color: 'green'
        }
    };

    console.log(firstPerson);
    console.log(thirdPerson);
    console.log(secondPerson);
}

solve();