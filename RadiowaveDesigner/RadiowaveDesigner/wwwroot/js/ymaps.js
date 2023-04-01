function init() {
    var myPlacemark,
        map = new ymaps.Map('maps', {
            center: [55.753994, 37.622093],
            zoom: 9
        }, {
            searchControlProvider: 'yandex#search'
        });

    map.events.add('click', function (e) {
        var coords = e.get('coords');
        
        if (myPlacemark) {
            map.geoObjects.remove(myPlacemark);
            myPlacemark = createPlacemark(coords);
            map.geoObjects.add(myPlacemark);
        } else {
            myPlacemark = createPlacemark(coords);
            map.geoObjects.add(myPlacemark);
        }
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

ymaps.ready(init);