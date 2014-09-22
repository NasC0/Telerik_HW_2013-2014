//////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 2. Using jQuery implement functionality to insert a DOM element before or after another element //
//////////////////////////////////////////////////////////////////////////////////////////////////////////

window.onload = function() {
    function insertNearElement($element, $elementToInsert, position) {
        if (position.toLowerCase() === 'before') {
            $elementToInsert.insertBefore($element);
        } else if (position.toLowerCase() === 'after') {
            $elementToInsert.insertAfter($element);
        }
    }

    var $element = $('.item-3');
    var $elementToInsert = $('<li>Inserted near element</li>');
    insertNearElement($element, $elementToInsert, 'before');
}