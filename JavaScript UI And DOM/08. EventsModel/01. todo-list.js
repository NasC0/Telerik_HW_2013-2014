///////////////////////////////////////////////////////////////
// Task 1. Create a TODO list with the following UI controls //
// Form input for new Item                                   //
// Button for adding the new Item                            //
// Button for deleting some item                             //
// Show and Hide Button                                      //
///////////////////////////////////////////////////////////////


window.onload = function() {
    function makeListEntryTemplate() {
        var listItemTemplate = document.createElement('li');
        listItemTemplate.className += ' todo-entry';

        var removeBtnTemplate = document.createElement('a');
        removeBtnTemplate.href = '#';

        var removeBtnImage = document.createElement('img');
        removeBtnImage.src = 'images\\delete.png';
        removeBtnTemplate.appendChild(removeBtnImage);

        var listItemContentsTemplate = document.createElement('span');
        listItemTemplate.appendChild(removeBtnTemplate);
        listItemTemplate.appendChild(listItemContentsTemplate);

        return listItemTemplate;
    }

    var showHideBtn = document.getElementById('todo-list-show-btn');

    showHideBtn.addEventListener('click', function(ev) {
        var todoListBody = ev.target.nextElementSibling;

        if (todoListBody.style.display === 'none') {
            todoListBody.style.display = '';
            showHideBtn.innerHTML = 'Hide list';
        } else {
            todoListBody.style.display = 'none';
            showHideBtn.innerHTML = 'Show list';
        }
    });

    var listItemTemplate = makeListEntryTemplate();
    var todoList = document.getElementById('todo-list');
    var inputField = document.getElementById('todo-input');
    var addButton = document.getElementById('todo-list-add-btn');

    addButton.addEventListener('click', function() {
        var elementContents = inputField.value;
        var listEntry = listItemTemplate.cloneNode(true);
        listEntry.lastChild.innerHTML = elementContents;
        todoList.appendChild(listEntry);
    });

    todoList.addEventListener('click', function(ev) {
        var target = ev.target;

        if (!(target instanceof HTMLImageElement)) {
            return;
        }

        var listElement = target.parentElement.parentElement;
        listElement.parentElement.removeChild(listElement);
    });
};