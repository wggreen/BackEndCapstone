var map;

var tour = {};
tour.saved = false

var destinations = []

async function getVenues() {
    try {
        const venues = await fetch(`/User/GetVenues`).then(res => res.json())
        return venues
    }
    catch (err) {
        console.log(err)
    }
}

window.addEventListener("beforeunload", function (event) {
    if (event.target.activeElement.id != "tourNameButton") {
        if (event.target.activeElement.id != "saveTourButton") {
            event.preventDefault(); // for Firefox
            event.returnValue = 'Are you sure you want to leave?'; // for Chrome
            return 'Are you sure you want to leave?';
        }
    }
});


function generateCard(venue) {
    try {
        var stopNumber = parseInt(document.getElementById("cards").lastElementChild.classList[3])
    }
    catch {
        var stopNumber = 0
    }

    var newLi = document.createElement("li")
    newLi.style = "font-size: 1.5em !important"

    var venueName = venue.name
    if (venueName.includes(" ")) {
        venueName = venueName.split(" ")
        venueName = venueName.join("-")
    }

    var venueCity = venue.city
    if (venueCity.includes(" ")) {
        venueCity = venueCity.split(" ")
        venueCity = venueCity.join("-")
    }

    var venueState = venue.state
    if (venueState.includes(" ")) {
        venueState = venueState.split(" ")
        venueState = venueState.join("-")
    }

    newLi.classList.add(`${venueName}`)
    newLi.classList.add(`${venueCity}`)
    newLi.classList.add(`${venueState}`)
    newLi.classList.add(`${stopNumber}`)
    document.getElementById("cards").insertAdjacentElement("beforeEnd", newLi)

    var contentTarget = document.getElementsByClassName(`${venueName} ${stopNumber} ${venueCity} ${venueState}`)[0]

    var newSpan = document.createElement("span")
    newSpan.style = "font-size: 0.75em !important"
    newSpan.classList.add(`span--${venueName}`)
    newSpan.classList.add(`span--${stopNumber}`)
    contentTarget.insertAdjacentElement("beforeEnd", newSpan)

    var spanTarget = document.getElementsByClassName(`span--${venueName} span--${stopNumber}`)[0]

    var newHeader = document.createElement("h3")
    var newContent = document.createTextNode(`${venue.name}`)
    newHeader.appendChild(newContent)
    spanTarget.insertAdjacentElement("beforeEnd", newHeader)

    var newDiv = document.createElement("div")
    newContent = document.createTextNode(`${venue.city}, ${venue.state}`)
    newDiv.appendChild(newContent)
    spanTarget.insertAdjacentElement("beforeEnd", newDiv)

    var newButton = document.createElement("button")
    newButton.classList.add("deleteCard")
    newButton.classList.add(`${venueCity}`)
    newButton.classList.add(`${stopNumber}`)
    newContent = document.createTextNode("Delete")
    newButton.appendChild(newContent)
    newButton.addEventListener("click", event => {
        newButton.parentElement.outerHTML = ""
    })
    contentTarget.insertAdjacentElement("beforeEnd", newButton)

    document.getElementById("saveTourButton").classList.remove("hidden")
}

async function getTourByName(name) {
    const foundTour = await fetch(`Tour/GetTourByName?name=${name}`).then(res => res.json())
    return foundTour
}

async function editTour(formData) {
    const dataObj = await fetch("/Tour/Edit", {
        method: "Post",
        body: formData
    }).then(res => res.json())
}

async function createDestination(formData) {
    const dataObj = await fetch("/Destination/Create", {
        method: "Post",
        body: formData
    }).then(res => res.json())
}

async function deleteDestination(id) {
    const dataObj = await fetch(`/Destination/Delete?id=${id}`, {
        method: "Post",
    }).then(res => res.json())
}

async function initMap() {

    tour.name = document.getElementById("tourName").textContent

    var deleteCards = document.querySelectorAll(".deleteCard")
    deleteCards.forEach(dc => {
        dc.addEventListener("click", event => {
            event.target.parentElement.outerHTML = ""
        })
    })

    document.getElementById("editTourButton").addEventListener("click", event => {
        event.preventDefault()
        document.getElementById("tourName").classList.add("hidden")
        document.getElementById("tourNameForm2").classList.remove("hidden")
        document.getElementById("tourNameInput2").value = tour.name
        event.target.classList.add("hidden")
        document.getElementById("saveTourButton").classList.add("hidden")
        var deleteCards = document.getElementsByClassName("deleteCard")
        var deleteCardsArray = Array.from(deleteCards)
        deleteCardsArray.forEach(dc => {
            dc.classList.add("hidden")
        })
    })

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
                    var contentTarget = document.querySelector("#panel")

                    if (contentTarget.hasChildNodes()) {
                        contentTarget.innerHTML = ""
                    }

                    var newDiv = document.createElement("div")
                    newDiv.id = "mapPane"
                    contentTarget.insertAdjacentElement("beforeEnd", newDiv)

                    newDivTarget = document.getElementById("mapPane")

                    var newHeader = document.createElement("h1")
                    var newContent = document.createTextNode(`${venue.name}`)
                    newHeader.appendChild(newContent)
                    newDivTarget.insertAdjacentElement("beforeEnd", newHeader)

                    var newHeader2 = document.createElement("h3")
                    newContent = document.createTextNode(`${venue.city}, ${venue.state}`)
                    newHeader2.appendChild(newContent)
                    newDivTarget.insertAdjacentElement("beforeEnd", newHeader2)

                    var newHeader3 = document.createElement("h6")
                    newContent = document.createTextNode(`${venue.capacity}`)
                    newHeader3.appendChild(newContent)
                    newDivTarget.insertAdjacentElement("beforeEnd", newHeader3)

                    var newDiv2 = document.createElement("div")
                    newContent = document.createTextNode(`${venue.blurb}`)
                    newDiv2.appendChild(newContent)
                    newDivTarget.insertAdjacentElement("beforeEnd", newDiv2)

                    var newButton = document.createElement("button")
                    newButton.classList.add("addToTourButton")
                    newContent = document.createTextNode("Add to tour")
                    newButton.appendChild(newContent)
                    newButton.addEventListener("click", event => {
                        generateCard(venue)
                    })
                    newDivTarget.insertAdjacentElement("beforeEnd", newButton)

                    contentTarget.classList.remove("hidden")

                }
            })(marker));
        }
    })
}

document.getElementById("tourNameButton2").addEventListener("click", async event => {
    event.preventDefault();

    try {
        var foundTour = await getTourByName(document.getElementById("tourNameInput2").value)
        alert("You already have a different tour by that name. Please pick a different one.")
    }

    catch {
        tour.name = document.getElementById("tourNameInput2").value
        document.getElementById("tourNameForm2").classList.add("hidden")
        document.getElementById("tourName").innerHTML = document.getElementById("tourNameInput2").value
        document.getElementById("tourName").classList.remove("hidden")
        document.getElementById("editTourButton").classList.remove("hidden")
        document.getElementById("saveTourButton").classList.remove("hidden")
        var deleteCards = document.getElementsByClassName("deleteCard")
        var deleteCardsArray = Array.from(deleteCards)
        deleteCardsArray.forEach(dc => {
            dc.classList.remove("hidden")
        })
    }
})

document.getElementById("saveTourButton").addEventListener("click", async event => {
    var stopList = document.getElementById("cards")
    if (stopList.hasChildNodes()) {

        let formData = new FormData();
        formData.append('name', tour.name)
        formData.append('userId', document.getElementById("userIdInput").value)
        formData.append('saved', true)
        formData.append('tourId', parseInt(document.getElementById("tourIdInput").value))
        await editTour(formData)

        var stops = stopList.children
        var stopsArray = Array.from(stops)
        stopsArray.forEach(stop => {
            var destination = {
                name: stop.classList[0],
                userId: document.getElementById("userIdInput").value,
                tourId: parseInt(document.getElementById("tourIdInput").value),
                city: stop.classList[1],
                state: stop.classList[2]
            }
            destinations.push(destination)
        })

        await deleteDestination(parseInt(document.getElementById("tourIdInput").value))

        var index = 0
        formData = new FormData();
        destinations.forEach(destination => {
            formData.append("[" + index + "].name", destination.name)
            formData.append("[" + index + "].userId", destination.userId)
            formData.append("[" + index + "].tourId", destination.tourId)
            formData.append("[" + index + "].city", destination.city)
            formData.append("[" + index + "].state", destination.state)

            index++
        })
        await createDestination(formData)

        window.location.href = '/Tour'

    }
    else {
        alert("You can't save an empty tour. Please add some stops")
    }
})