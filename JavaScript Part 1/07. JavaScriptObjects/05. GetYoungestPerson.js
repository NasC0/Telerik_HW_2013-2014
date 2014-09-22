///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 5. Write a function that finds the youngest person in a given array of persons and prints his/hers full name //
// Each person have properties firstname, lastname and age                                                           //
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function solve() {

    function findYoungestPerson(persons) {
        var youngestPerson;
        var minAge = 9007199254740992;

        for (var person in persons) {
            if (persons[person].age < minAge) {
                minAge = persons[person].age;
                youngestPerson = persons[person];
            }
        }

        return youngestPerson;
    }

    var persons = [{
        firstname: 'Pesho',
        lastName: 'Gosho',
        age: 25
    }, {
        firstname: 'Tisho',
        lastName: 'Tishev',
        age: 30
    }, {
        firstname: 'Iliq',
        lastName: 'Filiq',
        age: 18
    }];

    var youngestPerson = findYoungestPerson(persons);

    console.log(youngestPerson);
}

solve();