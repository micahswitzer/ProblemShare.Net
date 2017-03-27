module.exports = {
    minifyless: {
        src: ['less/temp/*.less'],
        dest: "less/icons.less",
        replacements: [{
                from: /^\s*$/gm,
                to: ""
            }]
    }
};
//# sourceMappingURL=replace.js.map 
//# sourceMappingURL=replace.js.map