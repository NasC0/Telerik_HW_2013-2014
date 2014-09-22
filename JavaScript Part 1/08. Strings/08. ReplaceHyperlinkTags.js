// Task 8. Write a JavaScript function that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].

function solve() {
    function replaceHyperlinkTags(htmlText) {
        var duplicate = htmlText;
        var subStrings = [];
        var currentString = '';

        while (true) {
            htmlText = htmlText.substring(htmlText.indexOf('<a href='));
            var end = htmlText.indexOf('</a>');
            subStrings.push(htmlText.substring(0, end + 4));

            var secondStart = htmlText.indexOf('"') + 1;
            var secondEnd = htmlText.indexOf('>') - 1;
            currentString += '[URL=' + htmlText.substring(secondStart, secondEnd) + ']';

            htmlText = htmlText.substring(htmlText.indexOf('>') + 1);
            currentString += htmlText.substring(0, htmlText.indexOf('<')) + '[/URL]';
            subStrings.push(currentString);

            currentString = '';

            if (htmlText.indexOf('<a href=') === -1) {
                break;
            } else {
                htmlText = htmlText.substring(htmlText.indexOf('<a href='));
            }
        }

        return subStrings;
    }

    function replaceTags(htmlText, subStrings) {
        for (var i = 0; i < subStrings.length; i += 2) {
            var toReplace = subStrings[i];
            var replaced = subStrings[i + 1];
            htmlText.replace(toReplace, replaced);
        }

        return htmlText;
    }

    var input = '<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

    var subStrings = replaceHyperlinkTags(input);
    var replaced = replaceTags(input, subStrings);

    console.log(replaced);
}

solve();