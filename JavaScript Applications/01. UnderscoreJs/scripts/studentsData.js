define(['student'], function(Student) {
    var students = [];

    students.push(new Student('Marin', 'Atanasov', 30, [2, 3, 4, 5]));
    students.push(new Student('Pesho', 'Peshev', 12, [3, 4, 5, 6]));
    students.push(new Student('Angel', 'Karaliichev', 35, [1, 2, 3, 4]));
    students.push(new Student('Mihali', 'Stoqnov', 20, [4, 5, 6, 7]));
    students.push(new Student('Georgi', 'Kamburov', 23, [5, 6, 7, 8]));
    students.push(new Student('Iliq', 'Borisov', 23, [5, 6, 7, 8]));
    students.push(new Student('Pesho', 'Mishev', 12, [3, 4, 5, 6]));
    students.push(new Student('Pesho', 'Atanasov', 12, [3, 4, 5, 6]));
    students.push(new Student('Pesho', 'Peshev', 12, [3, 4, 5, 6]));
    students.push(new Student('Tosho', 'Atanasov', 12, [3, 4, 5, 6]));
    students.push(new Student('Vasil', 'Atanasov', 30, [2, 3, 4, 5]));

    return students;
});