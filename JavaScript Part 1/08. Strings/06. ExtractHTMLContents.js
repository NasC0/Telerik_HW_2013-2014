// Task 6. Write a function that extracts the content of a html page given as text. The function should return anything that is in a tag, without the tags.

function solve() {
    function extractTitle(htmlText) {
        var hasTitle = htmlText.indexOf('<title>');

        if (hasTitle !== -1) {
            var startIndex = hasTitle + 7;
            var length = htmlText.indexOf('</title>') - startIndex;
            var title = htmlText.substring(startIndex, length);

            return title;
        }

        return -1;
    }

    function extractText(htmlText) {
        var startIndex = htmlText.indexOf('<body>') + 6;
        var innerHtml = htmlText.substring(startIndex);
        var title = extractTitle(htmlText);
        var matchText = innerHtml.match(/(?<=\>).*?(?=<)/);

        var result = '';

        if (title !== -1) {
            result += title;
        }

        for (var i in matchText) {
            result += matchText[i];
        }

        return result;
    }

    var html = '<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">Telerik Academy</a>aims to provide free real-world practicaltraining for young people who want to turn into skillful .NET software engineers.</p></body> </html>';

    var result = extractText(html);
    console.log(result);
}