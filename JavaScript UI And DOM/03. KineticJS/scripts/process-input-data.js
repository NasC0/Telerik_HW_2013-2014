function FamilyNode(mother, father, children, depth, directChildren) {
    this.mother = mother;
    this.father = father;
    this.children = children;
    this.depth = depth;
    this.directChildren = directChildren;

    var motherShape;
    var fatherSHape;
}

function SingleNode(name, depth) {
    this.name = name;
    this.depth = depth;

    var shape;
}

function Shape(text, rectangle) {
    this.text = text;
    this.rectangle = rectangle;
}

function findAncestors(originalFamilyTree) {
    for (var i = 0; i < originalFamilyTree.length; i++) {

        var currentMotherName = originalFamilyTree[i].mother;
        var currentFatherName = originalFamilyTree[i].father;

        var isPresent = false;

        for (var j = 0; j < originalFamilyTree.length; j++) {
            var currentNodeChildren = originalFamilyTree[j].children;

            for (var p = 0; p < currentNodeChildren.length; p++) {
                if (currentMotherName === currentNodeChildren[p] || currentFatherName === currentNodeChildren[p]) {
                    isPresent = true;
                }
            }
        }

        if (!isPresent) {
            return originalFamilyTree[i];
        }
    }
}

function getFamilyNode(parentName, familyTree) {
    for (var i = 0; i < familyTree.length; i++) {
        if (familyTree[i].mother === parentName || familyTree[i].father === parentName) {
            return familyTree[i];
        }
    }
}

function getTreeHiearchy(ancestors, familyTree, depth) {
    var mother = ancestors.mother;
    var father = ancestors.father;

    var unprocessedChildren = ancestors.children;
    var childrenNodes = [];

    for (var i = 0; i < unprocessedChildren.length; i++) {
        var currentChild = unprocessedChildren[i];
        var currentChildFamilyNode = getFamilyNode(currentChild, familyTree);

        if (currentChildFamilyNode === undefined) {
            var singleNode = new SingleNode(currentChild, depth + 1);
            childrenNodes.push(singleNode);

            continue;
        }

        var currentNodeChildren = getTreeHiearchy(currentChildFamilyNode, familyTree, depth + 1);

        childrenNodes.push(currentNodeChildren);
    }

    var familyNode = new FamilyNode(mother, father, childrenNodes, depth, unprocessedChildren);
    return familyNode;
}

function getFullHiearchy(familyTree) {
    var primeAncestors = findAncestors(familyTree);
    var hiearchy = getTreeHiearchy(primeAncestors, familyTree, 0);

    return hiearchy;
}