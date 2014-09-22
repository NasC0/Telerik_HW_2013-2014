require(['jquery', 'toastr', 'handlebars', 'oauth'], function ($, toastr) {

    function getAuthPromise() {
        OAuth.initialize('CziAuC3ZsmDC0hUGDtv-Mo8eIZM');
        var authPromise = OAuth.popup('twitter', {
            cache: true
        });

        return authPromise;
    }

    function showTweets(response, screenName) {
        processTwitterLinks(response);
        console.log(response);
        var tweetsTemplate = Handlebars.compile($('#twitter-feed-template').html()),
            resultHtml = tweetsTemplate({
                tweet: response,
                screenName: response[0].user.screen_name
            });
        
        $('.twitter-container').html(resultHtml);
    }

    function makeTwitterUsernameLinks(text) {
        var output,
            regex = /(^|[^@\w])@(\w{1,15})\b/g,
            replace = '$1<a href="http://twitter.com/$2">@$2</a>';

        output = text.replace(regex, replace);
        return output;
    }

    function makeTwitterHashtagLinks(text) {
        var output,
            regex = /(^|\s)#(\w*[a-zA-Z_]+\w*)/,
            replace = '$1<a href="http://twitter.com/hashtag/$2">#$2</a>'

        output = text.replace(regex, replace);
        return output;
    }

    function processTwitterLinks(response) {
        var i,
            len,
            currentTweet,
            hyperLinkedText;

        for (i = 0, len = response.length; i < len; i++) {
            currentTweet = response[i];
            hyperLinkedText = makeTwitterHashtagLinks(currentTweet.text);
            hyperLinkedText = makeTwitterUsernameLinks(hyperLinkedText);
            currentTweet.hyperlinkedText = hyperLinkedText;
        }
    }

    $('#authorize').on('click', function () {
        getAuthPromise()
        .done(function () {
            toastr.success('Authenticated succesfully. Your login authorization has been cached.');
        })
        .fail(function (err) {
            toastr.warning(err);
        });
    })

    $('#get-user').on('click', function () {
        var username = $('#username').val(),
            messageCount = parseInt($('#count').val());
        requestUrl = 'https://api.twitter.com/1.1/statuses/user_timeline.json?count=' + messageCount + '&screen_name=' + username + '&exclude_replies';
        getAuthPromise()
        .done(function (result) {
            result.get(requestUrl)
            .done(function (response) {
                showTweets(response);
                toastr.success('User messages recieved succesfully.');
            })
            .fail(function (error) {
                toastr.warning(error);
            });
        })
    });
});