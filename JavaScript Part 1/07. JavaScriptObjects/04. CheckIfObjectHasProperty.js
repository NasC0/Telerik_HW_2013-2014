//////////////////////////////////////////////////////////////////////////////////////
// Task 4. Write a function that checks if a given object contains a given property //
//////////////////////////////////////////////////////////////////////////////////////

function solve() {

    function hasProperty(obj, propertyName) {
        if (obj[propertyName] !== undefined) {
            return true;
        }

        return false;
    }

    var obj = {
        firstName: 'Tisho',
        lastName: 'Misho',
        age: 15
    };

    console.log('Object has property "length": ' + hasProperty(obj, 'length;'));
    console.log('Object has property "firstName": ' + hasProperty(obj, 'firstName'));
}

solve();