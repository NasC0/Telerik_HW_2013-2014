////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 6. Write a function that groups an array of persons by age, first or last name. The function must return an associative array, with keys - the groups, and values -arrays with persons in this groups //
// Use function overloading (i.e. just one function)                                                                                                                                                          //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function solve() {

    function Person(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    // I extended the function a bit, so it works with other objects as well
    // Still shows undefined if the passed in object does not possess the given property
    function groupBy(persons, property) {
        var groupedPeople = {};

        for (var person in persons) {
            if (groupedPeople[persons[person][property]] === undefined) {
                groupedPeople[persons[person][property]] = [];
            }

            groupedPeople[persons[person][property]].push(persons[person]);
        }

        return groupedPeople;
    }

    var pesho = new Person('Pesho', 'Peshev', 25);
    var grisho = new Person('Grisho', 'Peshev', 30);
    var tisho = new Person('Pesho', 'Tishev', 20);
    var tosho = new Person('Tosho', 'Toshev', 25);
    var personArray = [pesho, grisho, tisho, tosho];

    var groupedByAge = groupBy(personArray, 'lastName');

    console.log(groupedByAge);
}

solve();