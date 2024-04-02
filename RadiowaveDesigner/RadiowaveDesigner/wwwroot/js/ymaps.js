const baseStations = document.getElementById("baseStations").value;
const areaCoordinates = document.getElementById("areaCoordinates").value;

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
        const area = createCircleArea(
          element.Coordinates.Latitude,
          element.Coordinates.Longitude,
          element.PropagationRange,
          element.Existing,
          element.Automated);
        map.geoObjects.add(area);
        const placemark = createBaseStationPlacemark(element.Coordinates.Latitude, element.Coordinates.Longitude);
        map.geoObjects.add(placemark);
    });

    const designArea = createDesignArea(areaCoordinates);
    map.geoObjects.add(designArea);
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

function createCircleArea(latitude, longitude, radius, existing, automated) {
    let fillColor = "#13FA5977";
    let strokeColor = "#07842D";
    if (existing) {
        fillColor = "#8080ff";
        strokeColor = "#0000ff";
    }
    if (automated) {
        fillColor = "#b84dff"
        strokeColor = "#9900ff";
    }
    return new ymaps.Circle([
        [latitude, longitude],
        radius
    ], {
        hintContent: `Propagation range - ${radius} m`
    }, {
        draggable: false,
        fillColor: fillColor,
        fillOpacity: 0.2,
        strokeColor: strokeColor,
        strokeOpacity: 0.8,
        strokeWidth: 2
    });
}
function createDesignArea(configuration) {
    const configurationArray = JSON.parse(configuration);
    const coordinates = configurationArray[0].Coordinates.map(coord => [coord.Latitude, coord.Longitude]);

    return new ymaps.GeoObject({
        geometry: {
            type: 'Rectangle',
            coordinates: coordinates
        }
    }, {
        draggable: false,
        fillColor: '#DE755E',
        strokeColor: '#0000FF',
        opacity: 0.2,
        strokeWidth: 3
    });
}

ymaps.ready(init);