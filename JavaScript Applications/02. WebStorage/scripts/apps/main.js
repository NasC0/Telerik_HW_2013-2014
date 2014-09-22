require(['underscore', 'jquery', 'handlebars'], function(_, $) {
    var generatedNumber = Math.floor(Math.random() * 9000) + 1000,
        guessCount = 0,
        highscoreTemplate = Handlebars.compile($('#highscore-template').html()),
        userValue;

    function writeToStorage(nickname, guessCount) {
        var highscores = JSON.parse(localStorage.getItem('highscore'));
        if (!highscores) {
            highscores = [];
        }

        highscores.push({
            nickname: nickname,
            guesses: guessCount
        });

        localStorage.setItem('highscore', JSON.stringify(highscores));
        console.log(localStorage.getItem('highscores'));
    }

    function checkBovine(guessValue, number) {
        var numberString = number.toString(),
            sheepCount = 0,
            ramsCount = 0,
            i,
            currentDigit,
            cowPresent;

        for (i = 0; i < guessValue.length; i++) {
            currentDigit = guessValue[i];
            cowPresent = numberString.indexOf(currentDigit) !== -1;

            if (currentDigit === numberString[i]) {
                ramsCount++;
            } else if (cowPresent) {
                sheepCount++;
            }
        }

        return {
            rams: ramsCount,
            sheep: sheepCount
        };
    }

    $('#submit-guess').on('click', function() {
        var nickname = null,
            bovine,
            bovineMessage;

        $('#game-warning').html('');
        userValue = $('#value').val();
        if (userValue.length !== 4) {
            $('#game-warning').html("Input value must be 4 digits long.");
        } else if (isNaN(+userValue)) {
            $('#game-warning').html("Input value must be numeric.");
        } else {
            guessCount++;
            if (userValue === generatedNumber.toString()) {
                while (nickname === null) {
                    nickname = prompt('Please enter your nickname');
                }

                writeToStorage(nickname, guessCount);
                location.reload();
            }

            bovine = checkBovine(userValue, generatedNumber);
            bovineMessage = 'You found ' + bovine.rams + ' Rams and ' + bovine.sheep + ' Sheep.';
            $('#bovine-count').html(bovineMessage);
        }
    });

    $('#show-highscore').on('click', function() {
        var highscores = JSON.parse(localStorage.getItem('highscore'));
        var firstFiveScores;
        if (highscores) {
            firstFiveScores = _.chain(highscores)
                .sortBy(function(score) {
                    return score.guesses;
                })
                .last(5)
                .value();
        }
        $('#highscores').html(highscoreTemplate({
            highscore: firstFiveScores
        }));
    });
});