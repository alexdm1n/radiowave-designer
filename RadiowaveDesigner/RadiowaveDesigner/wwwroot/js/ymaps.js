const baseStations = document.getElementById("baseStations").value;

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
    
    const baseStationsArray = JSON.parse(baseStations);
    baseStationsArray.forEach((element) => {
        console.log(element);
        const area = createCircleArea(element.Coordinates.Latitude, element.Coordinates.Longitude, element.PropagationRange);
        map.geoObjects.add(area);
        const placemark = createBaseStationPlacemark(element.Coordinates.Latitude, element.Coordinates.Longitude);
        map.geoObjects.add(placemark);
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

function createBaseStationPlacemark(latitude, longitude) {
    return new ymaps.Placemark([latitude, longitude], {
        balloonContent: `${latitude},${longitude}`
    }, {
        preset: 'islands#circleIcon',
        iconColor: '#3caa3c'
    });
}

function createCircleArea(latitude, longitude, radius) {
    return new ymaps.Circle([
        [latitude, longitude],
        radius
    ], {
        hintContent: `Propagation range - ${radius} m`
    }, {
        draggable: false,
        fillColor: "#13FA5977",
        strokeColor: "#07842D",
        strokeOpacity: 0.8,
        strokeWidth: 2
    });
}

ymaps.ready(init);