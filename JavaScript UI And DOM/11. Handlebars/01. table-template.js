window.onload = function() {
    var tableTemplate = document.getElementById('table-template');
    var tableCompiled = Handlebars.compile(tableTemplate.innerHTML);

    var tableContent = [{
        title: 'Course Introduction',
        firstDate: 'Wed 18:00, 28-May-2014',
        secondDate: 'Thu 14:00, 29-May-2014'
    }, {
        title: 'Document Object Model',
        firstDate: 'Wed 18:00, 28-May-2014',
        secondDate: 'Thu 14:00, 29-May-2014'
    }, {
        title: 'HTML5 Canvas',
        firstDate: 'Thu 18:00, 29-May-2014',
        secondDate: 'Fri 14:00, 30-May-2014'
    }];

    // var tableContent = {
    //     title: 'Course Introduction',
    //     firstDate: 'Wed 18:00, 28-May-2014',
    //     secondDate: 'Thu 14:00, 29-May-2014'
    // };
    // 
    var tableHTML = tableCompiled({
        tableContent: tableContent
    });
    document.getElementById('table-container').innerHTML = tableHTML;
}