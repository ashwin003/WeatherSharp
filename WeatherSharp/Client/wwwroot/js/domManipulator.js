function updateDocumentTitle(title) {
    document.title = title;
    document.getElementById("title").innerText = title;
}

function readDocumentTitle() {
    return document.title;
}

function reload() {
    location.reload();
}

function drawMap(targetContainer, lattitude, longitude) {
    var map = new ol.Map({
        target: targetContainer,
        layers: [
            new ol.layer.Tile({
                source: new ol.source.OSM()
            })
        ],
        view: new ol.View({
            center: ol.proj.fromLonLat([longitude, lattitude]),
            zoom: 4
        })
    });

    console.log(map);
}