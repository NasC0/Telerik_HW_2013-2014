require.config({
    baseUrl: 'scripts/libs',
    paths: {
        student: '../objects/student',
        animal: '../objects/animal',
        book: '../objects/book'
    }
});

require(['../apps/main']);