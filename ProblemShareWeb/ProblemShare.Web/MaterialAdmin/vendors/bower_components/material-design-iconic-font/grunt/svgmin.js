module.exports = {
    test: {
        options: {
            plugins: [
                { removeViewBox: false }
            ]
        },
        files: [{
                expand: true,
                cwd: 'svg/2.1',
                src: ['*.svg'],
                dest: 'svg/new',
                ext: '.svg' // Dest filepaths will have this extension.
            }]
    }
};
//# sourceMappingURL=svgmin.js.map 
//# sourceMappingURL=svgmin.js.map