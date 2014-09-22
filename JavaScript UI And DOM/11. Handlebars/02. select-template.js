window.onload = function() {
    var selectTemplate = document.getElementById('select-template');
    var compiledTemplate = Handlebars.compile(selectTemplate.innerHTML);

    var options = [{
        value: 1,
        text: 'one'
    }, {
        value: 2,
        text: 'two'
    }, {
        value: 3,
        text: 'three'
    }, {
        value: 4,
        text: 'four'
    }];

    var compiledHTML = compiledTemplate({
        options: options
    });

    document.getElementById('select-container').innerHTML = compiledHTML;
};