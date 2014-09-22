function createImagesPreviewer(selector, items) {
    var previewerContainer = document.querySelector(selector);
    var docFragment = document.createDocumentFragment();

    var enlargedDiv = document.createElement('div');
    enlargedDiv.style.width = '75%';
    enlargedDiv.style.height = '500px';
    enlargedDiv.style.margin = '0 auto';
    enlargedDiv.style.display = 'inline-block';

    var previewDiv = document.createElement('div');
    previewDiv.style.float = 'right';
    previewDiv.style['overflow-y'] = 'scroll';
    previewDiv.style.height = (window.innerHeight - 50) + 'px';

    var filterHeader = document.createElement('h4');
    filterHeader.innerHTML = 'Filter';
    filterHeader.style.textAlign = 'center';

    var filterInput = document.createElement('input');
    filterInput.type = 'text';

    filterInput.addEventListener('keyup', function() {
        var searchValue = this.value.toLowerCase();

        if (searchValue === '') {
            for (var i = 1, length = previewDiv.childNodes.length; i < length; i++) {
                previewDiv.childNodes[i].style.display = '';
            }
        } else {
            for (var i = 1, length = previewDiv.childNodes.length; i < length; i++) {
                var titleNode = previewDiv.childNodes[i].firstChild.innerHTML.toLowerCase();
                if (titleNode.indexOf(searchValue) === -1) {
                    previewDiv.childNodes[i].style.display = 'none';
                } else {
                    previewDiv.childNodes[i].style.display = '';
                }
            }
        }
    });

    var filterDiv = document.createElement('div');
    filterDiv.appendChild(filterHeader);
    filterDiv.appendChild(filterInput);
    previewDiv.appendChild(filterDiv);

    var imageHeaderTemplate = document.createElement('h3');
    imageHeaderTemplate.style.textAlign = 'center';
    var imageElementTemplate = document.createElement('img');
    imageElementTemplate.style.borderRadius = '10px';
    imageElementTemplate.style.width = '150px';
    imageElementTemplate.style.height = '100px';
    imageElementTemplate.style.display = 'block';
    imageElementTemplate.style.margin = '0 auto';

    var imageContainerTemplate = document.createElement('div');
    imageContainerTemplate.style.width = '160px';
    imageContainerTemplate.style.height = '150px';

    for (var i = 0; i < items.length; i++) {
        var currentImageHeader = imageHeaderTemplate.cloneNode(true);
        currentImageHeader.innerHTML = items[i].title;
        var currentImageElement = imageElementTemplate.cloneNode(true);
        currentImageElement.setAttribute('src', items[i].url);
        var currentImageContainer = imageContainerTemplate.cloneNode(true);
        currentImageContainer.appendChild(currentImageHeader);
        currentImageContainer.appendChild(currentImageElement);

        currentImageContainer.addEventListener('mouseover', function(ev) {
            previewOnMouseover(ev);
        });

        currentImageContainer.addEventListener('mouseout', function(ev) {
            previewOnMouseout(ev);
        });

        currentImageContainer.addEventListener('click', function(ev) {
            var targetNode = getTargetNode(ev.target);
            previewOnMouseclick(targetNode);
        });

        if (i === 0) {
            previewOnMouseclick(currentImageContainer);
        }

        previewDiv.appendChild(currentImageContainer);
    }

    function getTargetNode(targetNode) {
        if (!(targetNode instanceof HTMLDivElement) && targetNode.parentElement instanceof HTMLDivElement) {
            return targetNode.parentElement;
        }

        return targetNode;
    }

    function previewOnMouseclick(targetNode) {
        if (enlargedDiv.hasChildNodes()) {
            enlargedDiv.removeChild(enlargedDiv.firstChild);
        }

        var clonedNode = targetNode.cloneNode(true);
        clonedNode.style.width = '100%';
        clonedNode.style.height = '100%';
        clonedNode.style.backgroundColor = '#FFF';
        clonedNode.lastChild.style.width = '100%';
        clonedNode.lastChild.style.height = '100%';
        enlargedDiv.appendChild(clonedNode);
    }

    function previewOnMouseout(ev) {
        var targetNode = getTargetNode(ev.target);
        targetNode.style.background = '#FFF';
    }

    function previewOnMouseover(ev) {
        var targetNode = getTargetNode(ev.target);
        targetNode.style.background = '#CCCCCC';
    }

    docFragment.appendChild(previewDiv);
    docFragment.appendChild(enlargedDiv);
    previewerContainer.appendChild(docFragment);
}