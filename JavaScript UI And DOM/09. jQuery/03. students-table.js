////////////////////////////////////////////////////////////////////////////////////////////
// Task 3. By given an array of students, generate a table that represents these students //
// Each student has first name, last name and grade                                       //
// Use jQuery                                                                             //
////////////////////////////////////////////////////////////////////////////////////////////

window.onload = function() {
    function makeStudentsTable(container, studentsList) {
        function convertStudentToTableEntry(student, $tableRowTemplate, $tableEntryTemplate) {
            var $firstNameTd = $tableEntryTemplate.clone(true).html(student.firstName);
            var $lastNameTd = $tableEntryTemplate.clone(true).html(student.lastName);
            var $gradeTd = $tableEntryTemplate.clone(true).html(student.grade);

            var $tableRow = $tableRowTemplate.clone(true)
                .append($firstNameTd)
                .append($lastNameTd)
                .append($gradeTd);

            return $tableRow;
        }


        var $studentsContainer = $(container);
        var $table = $(document.createElement('table'));
        var $tableRow = $(document.createElement('tr'));
        var $tableHead = $(document.createElement('th'));
        var $tableEntry = $(document.createElement('td'));

        var $headerRow = $tableRow.clone(true);
        $headerRow.append($tableHead.clone().html('First name'));
        $headerRow.append($tableHead.clone().html('Last name'));
        $headerRow.append($tableHead.clone().html('Grade'));
        $table.append($headerRow);

        for (var i in studentsList) {
            var $currentTableRow = convertStudentToTableEntry(studentsList[i], $tableRow, $tableEntry);
            $table.append($currentTableRow);
        }

        $studentsContainer.append($table);
    }

    var studentsList = [{
        firstName: 'Pesho',
        lastName: 'Goshev',
        grade: 6
    }, {
        firstName: 'Tosho',
        lastName: 'Toshev',
        grade: 3
    }, {
        firstName: 'Misho',
        lastName: 'Mishev',
        grade: 6
    }];

    var container = '#students-table-container';
    makeStudentsTable(container, studentsList);
};