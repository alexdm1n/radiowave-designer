function init() {
    let map = new ymaps.Map('maps', {
        center: [59.929753, 30.289624],
        zoom: 16
    });
}

ymaps.ready(init);