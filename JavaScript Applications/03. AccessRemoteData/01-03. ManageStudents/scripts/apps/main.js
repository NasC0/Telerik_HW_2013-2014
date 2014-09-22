////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 3. Using the REST API at 'localhost:3000/students' create a web application for managing students //
// I have combined jQuery AJAX with the module defined for task 1.                                        //
// GET and POST requests are handled by the requestModule                                                 //
// DELETE requests are handle by jQuery AJAX.                                                             //
////////////////////////////////////////////////////////////////////////////////////////////////////////////

require(['http-request-module', 'toastr', 'jquery'], function(requestModule, toastr, $) {
    var REQUEST_SERVER = 'http://localhost:3000/students';

    $(document).ready(function() {
        function addToTable(student, tableSelector) {
            var $trToAdd,
                $studentTd,
                $gradeTd,
                $deleteTd,
                $deleteButton;

            $studentTd = $('<td/>').html(student.name).addClass('text-center');
            $gradeTd = $('<td/>').html(student.grade).addClass('text-center');
            $deleteButton = $('<button/>')
                .html('Delete')
                .attr('id', student.id)
                .addClass('btn')
                .addClass('btn-warning')
                .addClass('delete-button');

            $deleteButton.on('click', deleteButtonClick);

            $deleteTd = $('<td/>').addClass('text-center').append($deleteButton);
            $trToAdd = $('<tr/>')
                .append($studentTd)
                .append($gradeTd)
                .append($deleteTd)
                .appendTo($(tableSelector));

            return $trToAdd;
        }

        function error(err) {
            toastr.warning(err);
        }

        function showStudents() {
            requestModule.getJSON(REQUEST_SERVER, ['application/json'], ['application/json'])
                .then(function(data) {
                    var parsedData = JSON.parse(data),
                        i,
                        currentStudent;

                    for (i in parsedData.students) {
                        currentStudent = parsedData.students[i];
                        addToTable(currentStudent, '#student-table');
                    }
                }, error);
        }

        function deleteButtonClick() {
            var $this = $(this),
                studentId = parseInt($this.attr('id'));

            $.ajax({
                url: REQUEST_SERVER + '/' + studentId,
                type: 'POST',
                data: {
                    _method: 'delete'
                }
            })
                .then(function() {
                    $('#student-table').empty();
                    showStudents();
                    toastr.warning('Succesfully deleted student.');
                }, error);
        }

        $('#add-student').on('click', function() {
            var studentName = $('#student-name').val(),
                grade = parseInt($('#student-grade').val()),
                student;

            if (studentName.length < 2) {
                toastr.warning('Student name must be at least 2 symbols long.');
                return;
            }

            if (isNaN(grade)) {
                toastr.warning('You must enter a valid student grade.');
                return;
            }

            student = {
                name: studentName,
                grade: grade
            };

            requestModule.postJSON(REQUEST_SERVER, student, ['application/json'], ['application/json'])
                .then(function(data) {
                    var parsedData = JSON.parse(data);
                    toastr.info(parsedData.name + ' added succesfully');
                    return parsedData;
                }, error)
                .then(function(parsedData) {
                    var $addedElement;
                    $addedElement = addToTable(parsedData, '#student-table');
                    return $addedElement;
                }, error)
                .then(function($element) {
                    $('html, body').animate({
                        scrollTop: $element.offset().top
                    }, 2000);
                }, function() {
                    toastr.warning("Can't scroll to element");
                });
        });

        showStudents();
    });
});