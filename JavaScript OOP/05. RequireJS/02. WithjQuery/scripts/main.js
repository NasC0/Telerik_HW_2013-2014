require(['jquery', '../test-data', 'jquery.ComboBox'], function($, data) {
    $(function() {
        var people = data;
        $('#combo-container').ComboBox('#combo-template', people);
    });
});