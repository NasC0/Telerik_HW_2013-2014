require.config({
    baseUrl: 'Scripts/libs',
    paths: {
        apps: '../apps',
        data: '../test-data',
        controls: '../apps/controls/controls'
    }
});

require(['apps/main']);