/////////////////////////////////////////////////////////////
// Task 1.                                                 //
// Create a module for working with DOM. The module        //
// should have the following functionality                 //
// Add DOM element to parent element given by selector     //
// Remove element from the DOM by given selector           //
// Attach event to given selector by given event type and  //
// event hander                                            //
// Add elements to buffer, which appends them to the       //
// DOM when their count for some selector becomes 100      //
// The buffer contains elements for each selector it gets  //
// Get elements by CSS selector                            //
// The module should reveal only the methods               //
/////////////////////////////////////////////////////////////

var domModule = (function() {
    var buffer = {};

    function processSelector(selector) {
        return selector.trim();
    }

    function appendChild(child, selector) {
        selector = processSelector(selector);
        var parentElement = document.querySelector(selector);
        parentElement.appendChild(child);
    }

    function removeChild(parentSelector, childSelector) {
        parentSelector = processSelector(parentSelector);
        childSelector = processSelector(childSelector);

        var parentElement = document.querySelector(parentSelector);
        var childElement = parentElement.querySelector(childSelector);
        childElement.parentElement.removeChild(childElement);
    }

    function addHandler(selector, eventType, eventHandler) {
        selector = processSelector(selector);
        var selectedElement = document.querySelector(selector);
        selectedElement.addEventListener(eventType, eventHandler);
    }

    function appendToBuffer(selector, childToAppend) {
        selector = processSelector(selector);
        if (buffer[selector] === undefined) {
            buffer[selector] = [];
        }

        buffer[selector].push(childToAppend);

        if (buffer[selector].length >= 100) {
            appendBufferToParent(selector);
            buffer[selector] = [];
        }
    }

    function appendBufferToParent(selector) {
        selector = processSelector(selector);
        var docFragment = document.createDocumentFragment();

        for (var i = 0; i < buffer[selector].length; i++) {
            docFragment.appendChild(buffer[selector][i]);
        }

        appendChild(docFragment, selector);
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    };

}());