define([
    "../../core",
    "../../selector"
], function (jQuery) {
    return function (elem, el) {
        // isHidden might be called from jQuery#filter function;
        // in that case, element will be second argument
        elem = el || elem;
        return jQuery.css(elem, "display") === "none" ||
            !jQuery.contains(elem.ownerDocument, elem);
    };
});
//# sourceMappingURL=isHidden.js.map 
//# sourceMappingURL=isHidden.js.map