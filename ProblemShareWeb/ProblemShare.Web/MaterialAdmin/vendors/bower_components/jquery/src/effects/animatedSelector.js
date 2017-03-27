define([
    "../core",
    "../selector",
    "../effects"
], function (jQuery) {
    jQuery.expr.filters.animated = function (elem) {
        return jQuery.grep(jQuery.timers, function (fn) {
            return elem === fn.elem;
        }).length;
    };
});
//# sourceMappingURL=animatedSelector.js.map 
//# sourceMappingURL=animatedSelector.js.map