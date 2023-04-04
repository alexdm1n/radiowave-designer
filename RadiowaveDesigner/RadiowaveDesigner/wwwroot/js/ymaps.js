const coordinates = document.getElementById("coordinates").value;
const propagationRange = document.getElementById("propagationRange").value;

function init() {
    var placemark,
        map = new ymaps.Map('maps', {
            center: [53.8760079219576,27.55503749137535],
            zoom: 10
        }, {
            searchControlProvider: 'yandex#search'
        });
    
    map.events.add('click', function (e) {
        const coords = e.get('coords');
        if(placemark) {
            map.geoObjects.remove(placemark);
            placemark = createPlacemark(coords);
            map.geoObjects.add(placemark);
        } else {
            placemark = createPlacemark(coords);
            map.geoObjects.add(placemark);
        }
    });
    
    const coordinatesArray = JSON.parse(coordinates);
    coordinatesArray.forEach((element) => {
        var area = createCircleArea(element.Latitude, element.Longitude, propagationRange);
        map.geoObjects.add(area);
      });
}

function createPlacemark(coords) {
    return new ymaps.Placemark(coords, {
        iconContent: 'click to see coordinates',
        balloonContent: coords
    }, {
        preset: 'islands#nightStretchyIcon',
        draggable: false,
        hasBalloon: true
    });
}

function createCircleArea(latitude, longitude, radius) {
    return new ymaps.Circle([
        [latitude, longitude],
        radius
    ], {
        hintContent: `ropagation range - ${radius}`
    }, {
        draggable: false,
        fillColor: "#DB709377",
        strokeColor: "#990066",
        strokeOpacity: 0.8,
        strokeWidth: 2
    });
}

ymaps.ready(init);