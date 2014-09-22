// Task 7. Write a script that parses an URL address given in the format: [protocol]://[server]/[resource]
// and extracts from it the [protocol], [server] and [resource] elements. Return the elements in a JSON object.

function solve() {

    function extractInfo(urlInfo) {
        var protocol = urlInfo.substring(0, urlInfo.indexOf(':'));
        var serverStartIndex = urlInfo.indexOf('/') + 2;
        var resourceStartIndex = urlInfo.indexOf('/', serverStartIndex);
        var server = urlInfo.substring(serverStartIndex, resourceStartIndex);
        var resource = urlInfo.substring(resourceStartIndex);

        var urlResources = {
            'protocol': protocol,
            'server': server,
            'resource': resource
        };

        return urlResources;
    }

    var urlInfo = document.getElementById('input').value;
    var result = extractInfo(urlInfo);

    var output = '<p>The extracted resources are:</p>';
    output += '<ul>';
    for (var i in result) {
        output += '<li>' + i + ': ' + result[i] + '</li>';
    }

    output += '</ul>';

    document.getElementById('output').innerHTML = output;
    return false;
}