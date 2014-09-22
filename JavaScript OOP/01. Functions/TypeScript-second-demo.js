var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Cat = (function (_super) {
    __extends(Cat, _super);
    function Cat(name, age, legs) {
        _super.call(this, name, age);
        this.age = age;
        this.legs = legs;
    }
    return Cat;
})(Animal);
