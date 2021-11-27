function getLocation() {
    var result = "Geolocation is not supported by this browser.";
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(t => result = t);
        console.log(result);
    }
    
    return result;
}