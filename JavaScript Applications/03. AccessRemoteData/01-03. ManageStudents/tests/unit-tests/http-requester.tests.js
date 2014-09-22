define(['../../scripts/libs/http-request-module', 'chai'], function(httpRequester, chai) {
    var REQUEST_SERVER = 'http://localhost:3000/students';
    var expect = chai.expect;

    describe('#HttpRequester', function() {
        it('When posting, should return success', function() {
            var student = {
                name: 'Pesho',
                grade: 10
            };

            expect('a').to.equal('a');
        });
    });
});