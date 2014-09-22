define(['animal'], function(Animal) {
    var animals = [];

    animals.push(new Animal('Cat', 2));
    animals.push(new Animal('Cat', 8));
    animals.push(new Animal('Bird', 100));
    animals.push(new Animal('Cat', 6));
    animals.push(new Animal('Bird', 2));

    return animals;
});