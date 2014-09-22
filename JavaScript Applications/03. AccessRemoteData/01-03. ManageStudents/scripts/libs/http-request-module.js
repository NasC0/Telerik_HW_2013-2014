////////////////////////////////////////////////////////////////////////////////////////////////////////
// Task 1. Create a module that exposes methods for performing HTTP requests by given URL and headers //
// getJSON and postJSON - Both methods should work with promises                                      //
////////////////////////////////////////////////////////////////////////////////////////////////////////

define(['q'], function(Q) {
    var getJSON, postJSON, getHttpRequest, makeRequest;
    getHttpRequest = (function() {
        var xmlHttpFactories;
        xmlHttpFactories = [

            function() {
                return new XMLHttpRequest();
            },
            function() {
                return new ActiveXObject("Msxml3.XMLHTTP");
            },
            function() {
                return new ActiveXObject("Msxml2.XMLHTTP.6.0");
            },
            function() {
                return new ActiveXObject("Msxml2.XMLHTTP.3.0");
            },
            function() {
                return new ActiveXObject("Msxml2.XMLHTTP");
            },
            function() {
                return new ActiveXObject("Microsoft.XMLHTTP");
            }
        ];
        return function() {
            var xmlFactory, _i, _len;
            for (_i = 0, _len = xmlHttpFactories.length; _i < _len; _i++) {
                xmlFactory = xmlHttpFactories[_i];
                try {
                    return xmlFactory();
                } catch (_error) {

                }
            }
            return null;
        };
    })();

    makeRequest = function(options) {
        var httpRequest,
            requestUrl,
            type,
            success,
            error,
            contentType,
            accept,
            data,
            deferred,
            i;

        deferred = Q.defer();
        httpRequest = getHttpRequest();
        options = options || {};
        //extract the values from the options and provide default values for the missing arguments
        requestUrl = options.url;
        type = options.type || 'GET';
        success = options.success || function() {};
        error = options.error || function() {};
        contentType = options.contentType || '';
        accept = options.accept || '';
        data = options.data || null;

        httpRequest.onreadystatechange = function() {
            if (httpRequest.readyState === 4) {
                switch (Math.floor(httpRequest.status / 100)) {
                    case 2:
                        deferred.resolve(httpRequest.responseText);
                        break;
                    default:
                        deferred.reject(httpRequest.responseText);
                        break;
                }
            }
        };
        httpRequest.open(type, requestUrl, true);

        for (i in contentType) {
            httpRequest.setRequestHeader('Content-Type', contentType[i]);
        }

        for (i in accept) {
            httpRequest.setRequestHeader('Accept', accept[i]);
        }

        httpRequest.send(data);

        return deferred.promise;
    };


    getJSON = function(url, contentTypeHeaders, acceptHeaders) {
        var options = {
            url: url,
            type: 'GET',
            contentType: contentTypeHeaders || ['application/json'],
            accept: acceptHeaders || ['application/json']
        };
        return makeRequest(options);
    };


    postJSON = function(url, data, contentTypeHeaders, acceptHeaders) {
        var options = {
            url: url,
            type: 'POST',
            data: JSON.stringify(data),
            contentType: contentTypeHeaders || ['application/json'],
            accept: acceptHeaders || ['application/json']
        };
        return makeRequest(options);
    };

    return {
        getJSON: getJSON,
        postJSON: postJSON
    };
});