require(['controls', 'data'], function(controls, data) {
    var people = data;
    var comboBox = new controls.ComboBox(people);
    var $container = comboBox.render('#combo-template');

    $('#combo-container').append($container);
});