function $(callback) {
    if (callback) {
        plugin.AddEventListener("OnReady", callback);
    }
}

$["on"] = function(event, callback) {
    if (event && callback) {
        plugin.AddEventListener(event, callback);
    }
}

$[""] = function() {
    
}