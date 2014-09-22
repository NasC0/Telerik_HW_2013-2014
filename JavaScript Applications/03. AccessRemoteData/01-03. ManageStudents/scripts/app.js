require.config({
    baseUrl: 'scripts/libs',
    shim: {
        'libs/jquery': {
            exports: '$'
        }
    }
});

require(['../apps/main']);