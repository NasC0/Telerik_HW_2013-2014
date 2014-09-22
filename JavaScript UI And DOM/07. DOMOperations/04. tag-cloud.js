////////////////////////////////////////////////////////////////////////////////////////
// Task 4. Create a tag cloud:                                                        //
// Visualize a string of tags (strings) in a given container                          //
// By given minFontSize and maxFontSize, generate the tags with different font-size,  //
// depending on the number of occurrences                                             //
////////////////////////////////////////////////////////////////////////////////////////


window.onload = function() {
    var INITIAL_WIDTH = 300;

    function generateTaglCloud(tags, minFontSize, maxFontSize) {
        var occurences = getWordOccurences(tags);
        var fontSizes = getFontSizeByOccurence(occurences, minFontSize, maxFontSize);

        var divElement = document.createElement('div');
        divElement.style.width = INITIAL_WIDTH + 'px';

        for (var i in occurences) {
            var currentElement = document.createElement('span');
            currentElement.innerHTML = i;
            currentElement.style.fontSize = fontSizes[occurences[i]] + 'px';
            currentElement.style.display = 'inline-block';
            currentElement.style.margin = getRandomValue(0, 30) + 'px';
            divElement.appendChild(currentElement);
        }

        return divElement;
    }

    function getRandomValue(min, max) {
        var randomValue = Math.floor(Math.random() * (max - min) + min);

        return randomValue;
    }

    function getWordOccurences(words) {
        var occurences = {};

        for (var i = 0; i < words.length; i++) {
            var currentWord = words[i];
            if (occurences[currentWord.toLowerCase()] !== undefined) {
                occurences[currentWord.toLowerCase()]++;
            } else {
                occurences[currentWord.toLowerCase()] = 1;
            }
        }

        return occurences;
    }

    function getFontSizeByOccurence(occurence, minFontSize, maxFontSize) {
        var allOccurences = [];
        for (var i in occurence) {
            if (allOccurences.indexOf(occurence[i]) === -1) {
                allOccurences.push(occurence[i]);
            }
        }

        allOccurences = allOccurences.sort();
        var occurenceAndFontSize = {};

        var step = parseInt((maxFontSize - minFontSize) / (allOccurences.length - 1));
        var startFontSize = minFontSize;

        for (var i = 0; i < allOccurences.length; i++) {
            occurenceAndFontSize[allOccurences[i]] = startFontSize;
            startFontSize += step;
        }

        return occurenceAndFontSize;

    }

    var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"];

    var generatedCloud = generateTaglCloud(tags, 17, 42);

    document.body.appendChild(generatedCloud);
};