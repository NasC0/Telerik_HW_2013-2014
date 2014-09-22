require(['underscore', '../studentsData', '../animalsData', '../booksData'], function(_, students, animals, books) {
    var highestMarkStudent,
        popularAuthor;


    console.log('------Compare names------');

    function getMostPopularProperty(collection, propertyName) {
        var countByProperty,
            maxCount,
            result,
            property;

        countByProperty = _.countBy(collection, propertyName);

        maxCount = _.max(countByProperty, function(obj) {
            return obj;
        });

        for (property in countByProperty) {
            if (countByProperty[property] === maxCount) {
                result = property;
            }
        }

        return result;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////
    // Task 1 - Finds all students whose first name is before its last name alphabetically.  //
    // Print the students in descending order by full name.                                  //
    ///////////////////////////////////////////////////////////////////////////////////////////
    _.chain(students)
        .filter(function(student) {
            return student.firstName() < student.lastName();
        })
        .sortBy(function(student) {
            return student.fullName();
        }).reverse()
        .each(function(student) {
            console.log(student);
        });

    console.log('--------Age between------');

    /////////////////////////////////////////////////////////////////////////////////////////////
    // Task 2 - finds the first name and last name of all students with age between 18 and 24. //
    /////////////////////////////////////////////////////////////////////////////////////////////

    _.chain(students)
        .filter(function(student) {
            return (student.age() >= 18 && student.age() <= 24);
        })
        .map(function(student) {
            return {
                firstName: student.firstName(),
                lastName: student.lastName()
            };
        })
        .each(function(student) {
            console.log(student);
        });

    console.log('------Highest Marks------');

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // Task 3 - Write a function that by a given array of students finds the student with highest marks //
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    function highestMarkStudents(students) {
        var highestMarkStudent = _.chain(students)
            .sortBy(function(student) {
                return student.marks();
            })
            .last().value();

        return highestMarkStudent;
    }

    highestMarkStudent = highestMarkStudents(students);
    console.log(highestMarkStudent);

    console.log('------Grouped species----');

    /////////////////////////////////////////////////////////////////
    // Task 4 - Write a function that by a given array of animals, //
    // groups them by species and sorts them by number of legs     //
    /////////////////////////////////////////////////////////////////

    function groupSpecies(animals) {
        var groupedSpecies = _.chain(animals)
            .sortBy(function(animal) {
                return animal.legs();
            }).groupBy(function(animal) {
                return animal.species();
            })
            .value();

        return groupedSpecies;
    }

    console.log(groupSpecies(animals));
    console.log('----------Legs-----------');

    /////////////////////////////////////////////////////////////////////////
    // Task 5 - By a given array of animals, find the total number of legs //
    /////////////////////////////////////////////////////////////////////////

    function getTotalLegs(animals) {
        var legsCount = _.reduce(animals, function(sumSoFar, animal) {
            return sumSoFar + animal.legs();
        }, 0);

        return legsCount;
    }

    console.log(getTotalLegs(animals));
    console.log('---------Author----------');

    ///////////////////////////////////////////////////////////////////////////
    // Task 6 - By a given collection of books, find the most popular author //
    ///////////////////////////////////////////////////////////////////////////

    // function mostPopularAuthor(books) {
    //     var authorsGrouped,
    //         maxBookCount,
    //         author;


    //     authorsGrouped = _.countBy(books, function(book) {
    //         return book.author();
    //     });

    //     maxBookCount = _.max(authorsGrouped, function(bookCount) {
    //         return bookCount;
    //     });

    //     for (var property in authorsGrouped) {
    //         if (authorsGrouped[property] === maxBookCount) {
    //             author = property;
    //         }
    //     }

    //     return author;
    // }

    var popularAuthor = getMostPopularProperty(books, '_author');
    console.log(popularAuthor);

    console.log('------Popular Names------');

    //////////////////////////////////////////////////////////////////////////////
    // Task 7 - By an array of people find the most common first and last name. //
    //////////////////////////////////////////////////////////////////////////////

    // function mostPopularFirstName(people) {
    //     var firstName,
    //         countByFirstName,
    //         maxCountFirstName,
    //         property;

    //     countByFirstName = _.countBy(people, function(person) {
    //         return person.firstName();
    //     });

    //     maxCountFirstName = _.max(countByFirstName, function(obj) {
    //         return obj;
    //     });

    //     for (property in countByFirstName) {
    //         if (countByFirstName[property] === maxCountFirstName) {
    //             firstName = property;
    //         }
    //     }

    //     return firstName;
    // }

    // function mostPopularLastName(people) {
    //     var lastName,
    //         countByLastName,
    //         maxCountLastName,
    //         property;

    //     countByLastName = _.countBy(people, function(person) {
    //         return person.lastName();
    //     });

    //     maxCountLastName = _.max(countByLastName, function(obj) {
    //         return obj;
    //     });

    //     for (property in countByLastName) {
    //         if (countByLastName[property] === maxCountLastName) {
    //             lastName = property;
    //         }
    //     }

    //     return lastName;
    // }

    console.log('First name: ' + getMostPopularProperty(students, '_firstName'));
    console.log('Last name: ' + getMostPopularProperty(students, '_lastName'));
});