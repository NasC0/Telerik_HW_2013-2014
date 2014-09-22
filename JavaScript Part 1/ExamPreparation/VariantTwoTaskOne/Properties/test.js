var bla = '     23     ';
var result = parseInt(bla);

if (isNaN(result)) {
    console.log(result);
}

var text = '(+ 2 3 (     +     1      2      2))';
text = text.replace('(', '');

var matches = text.match(/\((.*?)\)/)

console.log(matches);

console.log(matches[1]);

var match = matches[1].match(/[^ ]+/g)

console.log(match);

var bla = '-2';
var bar = bla + 1;

console.log(typeof result + ' ' + result);