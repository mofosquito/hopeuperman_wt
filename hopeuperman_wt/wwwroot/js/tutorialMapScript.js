var map = L.map('map').setView([2.3412195, 111.8418392], 18); //coordinates and zoom level

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

let locations = [
    {
        "id": 1,
        "lat": 2.3412195,
        "long": 111.8418392,
        "title": "UTS",
        "audio": "/audio/willsmith.mp3",
        "content": "The dialect spoken in this area is mainly <b>Engrish</b>",
        "instruct": "<i>Click on marker to hear sample audio.</i>"
    },

    {
        "id": 2,
        "lat": 2.2900863,
        "long": 111.8293576,
        "title": "Kampung Nyabor",
        "audio": "/audio/bung.mp3",
        "content": "The dialect spoken in this area is mainly <b>Balau</b>",
        "instruct": "<i>Click on marker to hear sample audio.</i>"
    }
]

locations.forEach(element => {
    new L.Marker([element.lat, element.long]).addTo(map)
        .on("mouseover", event => {
            event.target.bindPopup(element.title + "<br/><br/>" + element.content + "<br/><br/>" + element.instruct).openPopup();
        })
        .on("click", () => {
            window.open(element.audio);
        })
});