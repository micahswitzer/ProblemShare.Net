define([
    "../core"
], function (jQuery) {
    // Support: Android 2.3
    // Workaround failure to string-cast null input
    jQuery.parseJSON = function (data) {
        return JSON.parse(data + "");
    };
    return jQuery.parseJSON;
});
//# sourceMappingURL=parseJSON.js.map 
//# sourceMappingURL=parseJSON.js.map