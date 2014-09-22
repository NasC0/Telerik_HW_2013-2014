(function() {
    require.config({
        paths: {
            'jquery': 'libs/jquery',
            'handlebars': 'libs/handlebars',
            'controls': 'controls',
            'data': 'test-data'
        }
    });

    require(['jquery', 'controls', 'data'], function($, controls, data) {
        var people = data;

        var comboBox = new controls.ComboBox(people);
        var template = $('#combo-template').html();
        var $comboControl = comboBox.render(template);
        $('#combo-container').append($comboControl);
    });
}());