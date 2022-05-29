var map = L.map('map').setView([2.3412195, 111.8418392], 18); //coordinates and zoom level

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

//let locations = [
//    {
//        "id": 1,
//        "lat": 2.3412195,
//        "long": 111.8418392,
//        "title": "UTS",
//        "audio": "/audio/placeholder1.mp3",
//        "content": "The dialect spoken in this area is mainly <b>Engrish</b>",
//        "instruct": "<i>Click on marker to hear sample audio.</i>"
//    },

//    {
//        "id": 2,
//        "lat": 2.2900863,
//        "long": 111.8293576,
//        "title": "Kampung Nyabor",
//        "audio": "/audio/placeholder2.mp3",
//        "content": "The dialect spoken in this area is mainly <b>Balau</b>",
//        "instruct": "<i>Click on marker to hear sample audio.</i>"
//    },

//    {
//        "id": 3,
//        "lat": 2.2498425,
//        "long": 111.853018,
//        "title": "Lada",
//        "audio": "/audio/placeholder3.mp3",
//        "content": "The dialect spoken in this area is mainly <b>Hokkien</b>",
//        "instruct": "<i>Click on marker to hear sample audio.</i>"
//    },

//    {
//        "id": 4,
//        "lat": 2.299896,
//        "long": 111.89267,
//        "title": "Permai",
//        "audio": "/audio/placeholder4.mp3",
//        "content": "The dialect spoken in this area is mainly <b>Foochow</b>",
//        "instruct": "<i>Click on marker to hear sample audio.</i>"
//    },

//    {
//        "id": 5,
//        "lat": 2.3184297,
//        "long": 111.8301623,
//        "title": "Kampung Nangka",
//        "audio": "/audio/placeholder5.mp3",
//        "content": "The dialect spoken in this area is mainly <b>Bahasa Sarawak</b>",
//        "instruct": "<i>Click on marker to hear sample audio.</i>"
//    }
//]

//locations.forEach(element => {
//    new L.Marker([element.lat, element.long]).addTo(map)
//        .on("mouseover", event => {
//            event.target.bindPopup(element.title + "<br/><br/>" + element.content + "<br/><br/>" + element.instruct).openPopup();
//        })
//        .on("click", () => {
//            window.open(element.audio);
//        })
//});

$.ajax({
    type: "GET",
    url: '' + window.location.origin + '/Markers/GetLocation',
    success: function (data) {
        for (var i = 0; i < data.length; ++i) {
            var popup = '<b>Location Name:</b> ' + data[i].locationName +
                '<br/><b>Longitude:</b> ' + data[i].longitude +
                '<br/><b>Latitude:</b> ' + data[i].latitude +
                '<br/><b>Main Language:</b> ' + data[i].mainLanguage +
                '<br/><b>Dialect:</b> ' + data[i].dialect +
                '<br/><b>Audio:</b> ' + data[i].audioFile +
                '<br/><b>Translation:</b> ' + data[i].Translation +
                '<br/><b>Tag:</b> ' + data[i].tag;


            L.marker([data[i].latitude, data[i].longitude])
                .bindPopup(popup)
                .addTo(map);
        }

    },
    error: function (xhr) {

        console.log(xhr.responseText);
        alert("Error has occurred..");
    }
});

function onMapClick(e) {
    alert("You clicked the map at " + e.latlng);
}
map.on('click', onMapClick);