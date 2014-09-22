require.config({
    basseUrl: '../',
    paths: {
        mocha: './libs/mocha',
        chai: './libs/chai',
        jquery: '../scripts/libs/jquery',
        q: '../scripts/libs/q'
    }
});

require(['mocha'], function() {
        mocha.setup('bdd');
    require(['./unit-tests/http-requester.tests'], function() {
        mocha.run();
    });
});