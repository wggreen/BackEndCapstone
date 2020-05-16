async function getVenues() {
    try {
        const venues = await fetch(`/User/GetVenues`).then(res => res.json())
        return venues
    }
    catch (err) {
        console.log(err)
    }
}

async function getTours() {
    const tours = await fetch(`/Tour/GetTours/`).then(res => res.json())
    return tours
}

async function getTourByName(name) {
    const foundTour = await fetch(`Tour/GetTourByName?name=${name}`).then(res => res.json())
    return foundTour
}

function generateCard(venue) {
    document.getElementById("cards").innerHTML += `<li style="font-size: 1.5em !important" id="tourCard--${venue.id}"><span style="font-size: 0.75em !important"> <h3>${venue.name}</h3> <div>${venue.city}, ${venue.state}</div></span> <button id="deleteCard--${cardNumber}></button> </li>`

    cardNumber++;

    addDestination(venue);
}

async function addDestination(venue) {

    tour.userId = await getTourByName(tour.name).userId;

    let formData = new FormData();

    formData.append('name', venue.name)
    formData.append('userId', document.getElementById("userIdInput").value)
    formData.append('tourId', tour.tourId)

    const dataObj = await fetch("/Destination/Create", {
        method: "Post",
        body: formData
    }).then(res => res.json());

    var destination = {
        name: venue.name,
        userId: document.getElementById("userIdInput").value
    };

    destinations.push(destination);

    if (destinations.length == 1) {
        document.getElementById("saveTourButton").classList.remove("hidden")
    }
}

var map;
var tour = {};
var destinations = []

var cardNumber = 0;

async function initMap() {
    
    var venues = await getVenues();
        
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 39.5, lng: -98.35 },
        zoom: 3
    });

    google.maps.event.addListener(map, 'click', function () {
        const contentTarget = document.querySelector("#panel")
        contentTarget.classList.add("hidden")
        contentTarget.innerHTML = ""
    });
        
    var latlng = []

    venues.forEach(venue => {
        if (venue.userType == "venue") {
                
            var venueLat = parseInt(venue.lat);
            var venueLng = parseInt(venue.lng);
            var venueLatLng = [venueLat, venueLng];
            if (!latlng.includes(venueLatLng)) {
                var marker = new google.maps.Marker({
                    map: map,
                    position: { lat: venueLat, lng: venueLng },
                    title: venue.name
                });

                latlng.push([venueLat, venueLng]);

                google.maps.event.addListener(marker, 'click', (function (marker) {
                    return function () {
                        const contentTarget = document.querySelector("#panel")
                        contentTarget.innerHTML = `<div id="mapPane"><h1>${venue.name}</h1> <h3>${venue.city}, ${venue.state}</h3> <h6>Capacity: ${venue.capacity ? venue.capacity : 100}</h6> <div>${venue.blurb ? venue.blurb : 'we are cool'}</div> <button class="addToTourButton">Add to tour</button></div>`
                        document.getElementById("mapPane").addEventListener("click", event => {
                            if (event.target.nodeName == "BUTTON") {
                                if (tour.name) {
                                    generateCard(venue)
                                }
                                else {
                                    alert("You must first enter a tour")
                                }
                            }
                        })
                        contentTarget.classList.remove("hidden")
                    }
                })(marker));
            }
        }
    })        
}

document.getElementById("tourNameButton").addEventListener("click", async event => {
    event.preventDefault();

    try {
        var foundTour = await getTourByName(document.getElementById("tourNameInput").value)
        alert("You already have a tour by that name. Please pick a different one.")
    }
    catch {
        let formData = new FormData();
        formData.append('name', document.getElementById("tourNameInput").value)
        formData.append('userId', document.getElementById("userIdInput").value)
        formData.append('saved', false)

        const dataObj = await fetch("/Tour/Create", {
            method: "Post",
            body: formData
        }).then(res => res.json());

        var foundTour = await getTourByName(document.getElementById("tourNameInput").value)

        tour = {
            name: foundTour.name,
            userId: foundTour.userId,
            saved: foundTour.saved,
            tourId: foundTour.tourId
        };

        document.getElementById("tourName").classList.remove("hidden")
        document.getElementById("tourNameForm").classList.add("hidden")
        document.getElementById("tourName").innerHTML = document.getElementById("tourNameInput").value

        document.getElementById("editTourButton").classList.remove("hidden")
    }
})

window.addEventListener("beforeunload", function (event) {
    if (event.target.activeElement.id != "tourNameButton") {
        var confirmationMessage = 'It looks like you have been editing something. '
            + 'If you leave before saving, your changes will be lost.';

        (e || window.event).returnValue = confirmationMessage;
        return confirmationMessage;
    }
});

document.getElementById("editTourButton").addEventListener("click", event => {
    document.getElementById("tourName").classList.add("hidden")
    document.getElementById("tourNameForm2").classList.remove("hidden")
    document.getElementById("editTourButton").classList.add("hidden")
})

document.getElementById("tourNameButton2").addEventListener("click", async event => {

    event.preventDefault();

    tour.name = document.getElementById("tourNameInput2").value
    document.getElementById("tourNameForm2").classList.add("hidden")
    document.getElementById("tourName").innerHTML = document.getElementById("tourNameInput2").value
    document.getElementById("tourName").classList.remove("hidden")
    document.getElementById("editTourButton").classList.remove("hidden")

    let formData = new FormData();
    formData.append('name', document.getElementById("tourNameInput2").value)
    formData.append('userId', document.getElementById("userIdInput").value)
    formData.append('saved', false)
    formData.append('tourId', tour.tourId)

    const dataObj = await fetch(`/Tour/Edit?id=${tour.id}`, {
        method: "Post",
        body: formData
    }).then(res => res.json());
})