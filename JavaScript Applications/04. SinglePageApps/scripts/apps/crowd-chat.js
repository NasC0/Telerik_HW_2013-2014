require(['jquery', 'sammy', 'underscore', 'toastr', 'handlebars', 'plugins/sammy.handlebars'], function($, sammy, _, toastr) {
    var POSTS_URL = 'http://crowd-chat.herokuapp.com/posts';

    function resourceLoadError(err) {
        toastr.warning('Failed to load resource.');
        console.log(err);
        context.redirect('#/');
    }

    function replaceNbsp(text) {
        var replaced;
        replaced = text.replace(/&amp;nbsp;/g, "");
        return replaced;
    }

    function validateMessageObject(messageObj) {
        if (typeof(messageObj.user) !== 'string' || messageObj.user.length < 2) {
            toastr.warning('Your username should be at least 2 symbols long.');
            return false;
        } else if (typeof(messageObj.text) !== 'string' || messageObj.text <= 0) {
            toastr.warning('Your message should be at least 1 symbol long.');
            return false;
        }

        return true;
    }

    function sendMessage(username, message) {
        var messageObject = {
            user: username,
            text: message
        };

        if (validateMessageObject(messageObject)) {
            $.post(POSTS_URL, messageObject)
                .then(function() {
                    toastr.success('Message sent.');
                }, function() {
                    toastr.warning('Faled to send message.');
                });

            return true;
        } else {
            return false;
        }

    }

    function updateMessages(context) {
        var $messageContainer = context.$element().find('.container');
        var containerHeight;
        $.getJSON(POSTS_URL)
            .then(function(response) {
                var currentMessageCount = parseInt(sessionStorage.messageCount);
                if (response.length > currentMessageCount) {
                    var lastElements = _.last(response, (response.length - currentMessageCount));
                    _.each(lastElements, function(post) {
                        post.text = replaceNbsp(post.text);
                        var $resultHtml = context.render('views/show-posts.hb', {
                            post: post
                        });
                        $resultHtml.appendTo($messageContainer);
                    });
                    sessionStorage.messageCount = response.length;

                    return true;
                }
            }, resourceLoadError)
            .then(function(hasNewElements) {
                if (hasNewElements) {
                    containerHeight = $messageContainer.get(0).scrollHeight;
                    $messageContainer.scrollTop(containerHeight);
                }
            });
    }

    var crowdChat = sammy('#crowd-chat-body', function() {
        this.use('Handlebars', 'hb');

        this.get('#/', function(context) {
            context.app.swap('');
            var username = $('#username').val();
            context.render('views/select-username.hb', {
                username: username
            })
                .appendTo(context.$element());
        });

        this.post('#/', function(context) {
            var username = $('#username').val();
            if (typeof(username) !== 'string' || username.length <= 2) {
                toastr.warning('Username must be text with at least 2 symbols.');
            } else {
                sessionStorage.username = username;
                this.redirect('#/chat');
            }
        });

        this.get('#/chat', function(context) {
            var $messageContainer;
            if (!sessionStorage.username) {
                this.redirect('#/');
            }

            context.app.swap('');

            $(context.$element()).on('click', '#post-message', function() {
                var message = $('#message').val(),
                    isSentMessage = sendMessage(sessionStorage.username, message);

                if (isSentMessage) {
                    updateMessages(context);
                }
            });

            $messageContainer = $('<div/>').addClass('container').addClass('vertical-scroll');
            $.getJSON(POSTS_URL)
                .then(function(response) {
                    _.each(response, function(post) {
                        post.text = replaceNbsp(post.text);
                        context.render('views/show-posts.hb', {
                            post: post
                        })
                            .appendTo($messageContainer);
                    });

                    sessionStorage.messageCount = response.length;
                    $messageContainer.appendTo(context.$element());
                }, resourceLoadError);

            context.render('views/post-message.hb')
                .appendTo(context.$element());

            setInterval(function() {
                updateMessages(context);
            }, 2000);
        });
    });

    crowdChat.run('#/');
});