define(function() {
    var Student;
    Student = (function() {
        function Student(firstName, lastName, age, marks) {
            this.firstName(firstName);
            this.lastName(lastName);
            this.age(age);
            this.marks(marks);
        }

        Student.prototype.firstName = function(firstName) {
            if (firstName === undefined) {
                return this._firstName;
            } else {
                if (typeof(firstName) === 'string') {
                    this._firstName = firstName;
                }
            }
        };

        Student.prototype.lastName = function(lastName) {
            if (lastName === undefined) {
                return this._lastName;
            } else {
                if (typeof(lastName) === 'string') {
                    this._lastName = lastName;
                }
            }
        };

        Student.prototype.age = function(age) {
            if (age === undefined) {
                return this._age;
            } else {
                if (typeof(age) === 'number' && age > 0) {
                    this._age = age;
                }
            }
        };

        Student.prototype.marks = function(marks) {
            if (marks === undefined) {
                return this._marks;
            } else {
                if (marks instanceof Array) {
                    this._marks = marks;
                }
            }
        };

        Student.prototype.fullName = function() {
            return this.firstName() + ' ' + this.lastName();
        };

        return Student;
    }());

    return Student;
});